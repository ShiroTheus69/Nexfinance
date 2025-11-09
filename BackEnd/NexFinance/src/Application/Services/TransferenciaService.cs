using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NexFinance.Domain.Entities;
using NexFinance.src.Api.Data;
using NexFinance.src.Application.DTOs;
using NexFinance.src.Application.Interfaces;
using NexFinance.src.Application.Interfaces.Repositories;
using System;

namespace NexFinance.src.Application.Services {
    

    public class TransferenciaService : ITransferenciaService {
        private readonly ITransferenciaRepository _repo;
        private readonly IContaRepository _contaRepo;
        private readonly IMapper _mapper;
        private readonly NexFinanceContext _db;

        public TransferenciaService(ITransferenciaRepository repo, IContaRepository contaRepo, IMapper mapper, NexFinanceContext db) {
            _repo = repo;
            _contaRepo = contaRepo;
            _mapper = mapper;
            _db = db;
        }

        public async Task<TransferenciaDto> CreateAsync(CreateTransferenciaDto dto, CancellationToken ct = default) {
            if (dto.Valor <= 0)
                throw new ArgumentException("Valor inválido");
            if (dto.ContaOrigemId == dto.ContaDestinoId)
                throw new ArgumentException("Contas iguais");

            // transaction scope
            await using var tx = await _db.Database.BeginTransactionAsync(ct);
            try {
                // valida se contas existem
                var origem = await _contaRepo.GetByIdAsync(dto.ContaOrigemId, ct) ?? throw new InvalidOperationException("Conta origem não encontrada");
                var destino = await _contaRepo.GetByIdAsync(dto.ContaDestinoId, ct) ?? throw new InvalidOperationException("Conta destino não encontrada");

                // criar transferencia
                var transferencia = new Transferencia(dto.UsuarioId, dto.ContaOrigemId, dto.ContaDestinoId, dto.Valor, dto.Data, dto.Descricao);
                var created = await _repo.AddAsync(transferencia, ct);

                // opcional: criar lançamentos de débito/crédito (regra de negócio)
                // await _lancamentoRepo.AddAsync(...)

                await tx.CommitAsync(ct);
                return _mapper.Map<TransferenciaDto>(created);
            } catch {
                await tx.RollbackAsync(ct);
                throw;
            }
        }

        public Task DeleteAsync(int id, CancellationToken ct = default) {
            throw new NotImplementedException();
        }

        public async Task<TransferenciaDto?> GetByIdAsync(int id, CancellationToken ct = default) {
            var e = await _repo.GetByIdAsync(id, ct);
            return e == null ? null : _mapper.Map<TransferenciaDto>(e);
        }

        public async Task<IReadOnlyList<TransferenciaDto>> GetByUsuarioAsync(int usuarioId, CancellationToken ct = default) {
            var list = await _repo.ListByUsuarioAsync(usuarioId, ct);
            return _mapper.Map<IReadOnlyList<TransferenciaDto>>(list);
        }

        public Task<(IReadOnlyList<TransferenciaDto> Items, int Total)> GetByUsuarioPagedAsync(int usuarioId, int page, int pageSize, CancellationToken ct = default) {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, UpdateTransferenciaDto dto, CancellationToken ct = default) {
            throw new NotImplementedException();
        }
    }

}
