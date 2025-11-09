using AutoMapper;
using NexFinance.Domain.Entities;
using NexFinance.src.Application.DTOs;
using NexFinance.src.Application.Interfaces;
using NexFinance.src.Application.Interfaces.Repositories;

namespace NexFinance.src.Application.Services {
    

    public class ContaService : IContaService {
        private readonly IContaRepository _repo;
        private readonly IMapper _mapper;

        public ContaService(IContaRepository repo, IMapper mapper) {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ContaDto> CreateAsync(CreateContaDto dto, CancellationToken ct = default) {
            if (string.IsNullOrWhiteSpace(dto.Nome))
                throw new ArgumentException("Nome inválido");
            if (string.IsNullOrWhiteSpace(dto.Tipo))
                throw new ArgumentException("Tipo inválido");

            var conta = new Conta(dto.Nome.Trim(), dto.Tipo.Trim(), dto.IdUsuario);
            var created = await _repo.AddAsync(conta, ct);
            return _mapper.Map<ContaDto>(created);
        }

        public async Task<ContaDto?> GetByIdAsync(int id, CancellationToken ct = default) {
            var c = await _repo.GetByIdAsync(id, ct);
            return c == null ? null : _mapper.Map<ContaDto>(c);
        }

        public async Task<IReadOnlyList<ContaDto>> ListAsync(CancellationToken ct = default) {
            var list = await _repo.ListAsync(ct);
            return _mapper.Map<IReadOnlyList<ContaDto>>(list);
        }
    }

}
