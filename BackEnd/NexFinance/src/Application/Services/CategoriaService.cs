using AutoMapper;
using NexFinance.src.Application.DTOs;
using NexFinance.Domain.Entities;
using NexFinance.src.Application.Interfaces;
using NexFinance.src.Application.Interfaces.Repositories;

namespace NexFinance.src.Application.Services {
   

    public class CategoriaService : ICategoriaService {
        private readonly ICategoriaRepository _repo;
        private readonly IMapper _mapper;

        public CategoriaService(ICategoriaRepository repo, IMapper mapper) {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<CategoriaDto> CreateAsync(CreateCategoriaDto dto, CancellationToken ct = default) {
            if (string.IsNullOrWhiteSpace(dto.Nome))
                throw new ArgumentException("Nome inválido");
            if (!Enum.TryParse<Domain.Enums.TipoMovimento>(dto.Tipo, true, out var tipo))
                throw new ArgumentException("Tipo inválido");

            var entity = new Categoria(dto.Nome.Trim(), tipo, dto.Descricao?.Trim());
            var created = await _repo.AddAsync(entity, ct);
            return _mapper.Map<CategoriaDto>(created);
        }

        public async Task<CategoriaDto?> GetByIdAsync(int id, CancellationToken ct = default) {
            var c = await _repo.GetByIdAsync(id, ct);
            return c == null ? null : _mapper.Map<CategoriaDto>(c);
        }

        public async Task<IReadOnlyList<CategoriaDto>> ListAsync(CancellationToken ct = default) {
            var list = await _repo.ListAsync(ct);
            return _mapper.Map<IReadOnlyList<CategoriaDto>>(list);
        }
    }

}
