using AutoMapper;
using NexFinance.Domain.Entities;
using NexFinance.src.Application.DTOs;
using NexFinance.src.Application.Interfaces;
using NexFinance.src.Application.Interfaces.Repositories;
using NexFinance.src.Application.Security;
namespace NexFinance.src.Application.Services {
    

    public class UsuarioService : IUsuarioService {
        private readonly IUsuarioRepository _repo;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository repo, IMapper mapper) {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<UsuarioDto> CreateAsync(CreateUsuarioDto dto, CancellationToken ct = default) {
            // validações básicas
            if (string.IsNullOrWhiteSpace(dto.Nome))
                throw new ArgumentException("Nome inválido");
            if (string.IsNullOrWhiteSpace(dto.Cpf) || dto.Cpf.Length != 11)
                throw new ArgumentException("CPF inválido");
            if (string.IsNullOrWhiteSpace(dto.Email) || !dto.Email.Contains('@'))
                throw new ArgumentException("Email inválido");
            if (string.IsNullOrWhiteSpace(dto.SenhaPlain) || dto.SenhaPlain.Length < 8)
                throw new ArgumentException("Senha fraca");

            // verifica se já existe email
            var exist = await _repo.GetByEmailAsync(dto.Email, ct);
            if (exist != null)
                throw new InvalidOperationException("Email já cadastrado");

            var hashed = PasswordHasher.Hash(dto.SenhaPlain);

            var usuario = new Usuario(dto.Nome.Trim(), dto.Cpf.Trim(), dto.Email.Trim().ToLowerInvariant(), hashed, dto.Idade);

            var created = await _repo.AddAsync(usuario, ct);
            // mapear para DTO de resposta
            return _mapper.Map<UsuarioDto>(created);
        }

        public Task<UsuarioDto?> GetByIdAsync(int id, CancellationToken ct = default) {
            return _repo.GetByIdAsync(id, ct).ContinueWith(t => t.Result is null ? null : _mapper.Map<UsuarioDto>(t.Result), ct);
        }

        public async Task<UsuarioDto?> GetByEmailAsync(string email, CancellationToken ct = default) {
            var u = await _repo.GetByEmailAsync(email, ct);
            return u == null ? null : _mapper.Map<UsuarioDto>(u);
        }

        public Task<UsuarioDto?> AuthenticateAsync(string email, string senhaPlain, CancellationToken ct = default) {
            throw new NotImplementedException();
        }
    }

}
