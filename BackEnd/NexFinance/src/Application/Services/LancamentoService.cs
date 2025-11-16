using AutoMapper;
using NexFinance.Domain.Entities;
using NexFinance.Domain.Enums;
using NexFinance.src.Application.DTOs;
using NexFinance.src.Application.Interfaces;
using NexFinance.src.Application.Interfaces.Repositories;

namespace NexFinance.src.Application.Services {
    public class LancamentoService : ILancamentoService {
        private readonly ILancamentoRepository _repo;
        private readonly IMapper _mapper;

        public LancamentoService(ILancamentoRepository repo, IMapper mapper) {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<LancamentoDto> CreateAsync(CreateLancamentoDto dto, CancellationToken ct = default) {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            if (dto.Valor <= 0)
                throw new ArgumentException("O valor do lançamento deve ser maior que zero.");

            if (dto.Data == default)
                throw new ArgumentException("Data inválida.");

            if (!Enum.TryParse<TipoMovimento>(dto.Tipo, true, out var tipoMovimento))
                throw new ArgumentException("Tipo de movimento inválido.");

            var entity = new Lancamento(
                usuarioId: dto.UsuarioId,
                categoriaId: dto.CategoriaId,
                contaId: dto.ContaId,
                tipo: tipoMovimento,
                valor: dto.Valor,
                data: dto.Data,
                descricao: dto.Descricao
            );

            var created = await _repo.AddAsync(entity, ct);
            return _mapper.Map<LancamentoDto>(created);
        }

        public async Task DeleteAsync(int id, CancellationToken ct = default) {
            var lancamento = await _repo.GetByIdAsync(id, ct);
            if (lancamento == null)
                throw new KeyNotFoundException("Lançamento não encontrado.");

            await _repo.DeleteAsync(lancamento, ct);
        }

        public async Task<LancamentoDto?> GetByIdAsync(int id, CancellationToken ct = default) {
            var entity = await _repo.GetByIdAsync(id, ct);
            return entity == null ? null : _mapper.Map<LancamentoDto>(entity);
        }

        public async Task<(IReadOnlyList<LancamentoDto> Items, int Total)> GetByUsuarioPagedAsync(
            int usuarioId, int page, int pageSize, CancellationToken ct = default) {
            if (usuarioId <= 0)
                throw new ArgumentException("Usuário inválido.");
            if (page <= 0 || pageSize <= 0)
                throw new ArgumentException("Paginação inválida.");

            var (items, total) = await _repo.GetByUsuarioPagedAsync(usuarioId, page, pageSize, ct);
            var mappedItems = _mapper.Map<IReadOnlyList<LancamentoDto>>(items);
            return (mappedItems, total);
        }

        public async Task UpdateAsync(int id, UpdateLancamentoDto dto, CancellationToken ct = default) {
            var existing = await _repo.GetByIdAsync(id, ct);
            if (existing == null)
                throw new KeyNotFoundException("Lançamento não encontrado.");

            // Atualiza os campos mutáveis
            existing.Atualizar(
                categoriaId: dto.CategoriaId,
                contaId: dto.ContaId,
                tipo: Enum.TryParse<TipoMovimento>(dto.Tipo, true, out var tipo) ? tipo : existing.Tipo,
                valor: dto.Valor,
                data: dto.Data,
                descricao: dto.Descricao
            );

            await _repo.UpdateAsync(existing, ct);
        }
    }
}
