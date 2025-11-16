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

            await using var tx = await _db.Database.BeginTransactionAsync(ct);
            try {
                var origem = await _contaRepo.GetByIdAsync(dto.ContaOrigemId, ct) ?? throw new InvalidOperationException("Conta origem não encontrada");
                var destino = await _contaRepo.GetByIdAsync(dto.ContaDestinoId, ct) ?? throw new InvalidOperationException("Conta destino não encontrada");

                var transferencia = new Transferencia(dto.UsuarioId, dto.ContaOrigemId, dto.ContaDestinoId, dto.Valor, dto.Data, dto.Descricao);
                var created = await _repo.AddAsync(transferencia, ct);

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

        public async Task<(IReadOnlyList<TransferenciaDto> Items, int TotalCount)> GetByUsuarioPagedAsync(int usuarioId, int page, int pageSize, CancellationToken ct = default) {
            if (usuarioId <= 0)
                throw new ArgumentException("ID de usuário inválido.");

            if (page <= 0 || pageSize <= 0)
                throw new ArgumentException("Parâmetros de paginação inválidos.");

            try {
                var query = _db.Transferencias
                    .AsNoTracking()
                    .Where(t => t.UsuarioId == usuarioId)
                    .OrderByDescending(t => t.DataCriacao);

                var total = await query.CountAsync(ct);

                var entities = await query
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync(ct);

                var dtos = _mapper.Map<IReadOnlyList<TransferenciaDto>>(entities);

                return (dtos, total);
            } catch (Exception ex) {
                throw new InvalidOperationException("Erro ao buscar transferências paginadas do usuário.", ex);
            }
        }

        public Task UpdateAsync(int id, UpdateTransferenciaDto dto, CancellationToken ct = default) {
            throw new NotImplementedException();
        }
    }

}
