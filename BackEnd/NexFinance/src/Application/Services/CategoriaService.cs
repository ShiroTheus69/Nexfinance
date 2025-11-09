using AutoMapper;
using NexFinance.Domain.Entities;
using NexFinance.Domain.Enums;
using NexFinance.src.Application.DTOs;
using NexFinance.src.Application.Interfaces;
using NexFinance.src.Application.Interfaces.Repositories;
using NexFinance.src.Infrastructure.Repositories;

namespace NexFinance.src.Application.Services {
   

    public class CategoriaService : ICategoriaService {
        private readonly ICategoriaRepository _repo;
        private readonly IMapper _mapper;

        public CategoriaService(ICategoriaRepository repo, IMapper mapper) {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<CategoriaDto> CreateAsync(CreateCategoriaDto dto, CancellationToken ct) {
            // Converte string do DTO para enum com validação
            var tipo = dto.ToTipoMovimento();

            var categoria = new Categoria(dto.Nome, tipo, dto.Descricao);

            // Persiste no banco
            await _repo.AddAsync(categoria, ct);

            // Retorna DTO de leitura
            return new CategoriaDto(categoria.Id, categoria.Nome, categoria.Tipo.ToString(), categoria.Descricao);
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
