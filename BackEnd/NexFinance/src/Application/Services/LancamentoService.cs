using AutoMapper;
using NexFinance.Domain.Entities;
using NexFinance.src.Application.DTOs;
using NexFinance.src.Application.Interfaces;
using NexFinance.src.Application.Interfaces.Repositories;

namespace NexFinance.src.Application.Services {


    public class LancamentoService : ILancamentoService {
        private readonly ILancamentoRepository _repo;
        private readonly IMapper _mapper;

        public LancamentoService(ILancamentoRepository repo, IMapper mapper) {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<LancamentoDto> CreateAsync(CreateLancamentoDto dto, CancellationToken ct = default) {
            // validações básicas
            if (dto.Valor <= 0)
                throw new ArgumentException("Valor inválido");
            if (dto.Data == default)
                throw new ArgumentException("Data inválida");

            var entity = new Lancamento(dto.UsuarioId, dto.CategoriaId, dto.ContaId,
                                        Enum.TryParse<Domain.Enums.TipoMovimento>(dto.Tipo, true, out var t) ? t : throw new ArgumentException("Tipo inválido"),
                                        dto.Valor, dto.Data, dto.Descricao);

            var created = await _repo.AddAsync(entity, ct);
            return _mapper.Map<LancamentoDto>(created);
        }

        public Task DeleteAsync(int id, CancellationToken ct = default) {
            throw new NotImplementedException();
        }

        public async Task<LancamentoDto?> GetByIdAsync(int id, CancellationToken ct = default) {
            var e = await _repo.GetByIdAsync(id, ct);
            return e == null ? null : _mapper.Map<LancamentoDto>(e);
        }

        public async Task<(IReadOnlyList<LancamentoDto> Items, int Total)> GetByUsuarioPagedAsync(
            int usuarioId, int page, int pageSize, CancellationToken ct = default) {
            var (items, total) = await _repo.GetByUsuarioPagedAsync(usuarioId, page, pageSize, ct);

            var mappedItems = _mapper.Map<IReadOnlyList<LancamentoDto>>(items);
            return (mappedItems, total);
        }

        public Task UpdateAsync(int id, UpdateLancamentoDto dto, CancellationToken ct = default) {
            throw new NotImplementedException();
        }
    }

}
