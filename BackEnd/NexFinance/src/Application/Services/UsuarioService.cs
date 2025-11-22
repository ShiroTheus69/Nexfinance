using AutoMapper;
using NexFinance.Domain.Entities;
using NexFinance.src.Api.Data;
using NexFinance.src.Application.DTOs;
using NexFinance.src.Application.DTOs.Auth;
using NexFinance.src.Application.Interfaces;
using NexFinance.src.Application.Interfaces.Repositories;
using NexFinance.src.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NexFinance.src.Application.Services {
    public class UsuarioService : IUsuarioService {
        private readonly IUsuarioRepository _repo;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly ILogLoginRepository _logRepo;
        private readonly NexFinanceContext _db;

        public UsuarioService(
            IUsuarioRepository repo,
            IMapper mapper,
            ITokenService tokenService,
            ILogLoginRepository logRepo,
            NexFinanceContext db
        ) {
            _repo = repo;
            _mapper = mapper;
            _tokenService = tokenService;
            _logRepo = logRepo;
            _db = db;
        }

        public async Task<UsuarioDto> CreateAsync(CreateUsuarioDto dto, CancellationToken ct = default) {
            if (string.IsNullOrWhiteSpace(dto.Nome))
                throw new ArgumentException("Nome inválido");
            if (string.IsNullOrWhiteSpace(dto.Cpf) || dto.Cpf.Length != 11)
                throw new ArgumentException("CPF inválido");
            if (string.IsNullOrWhiteSpace(dto.Email) || !dto.Email.Contains('@'))
                throw new ArgumentException("Email inválido");
            if (string.IsNullOrWhiteSpace(dto.SenhaPlain) || dto.SenhaPlain.Length < 8)
                throw new ArgumentException("Senha fraca");

            var exist = await _repo.GetByCpfAsync(dto.Cpf, ct);
            if (exist != null)
                throw new InvalidOperationException("CPF já cadastrado");

            var hashed = BCrypt.Net.BCrypt.HashPassword(dto.SenhaPlain);

            var usuario = new Usuario(
                dto.Nome.Trim(),
                dto.Cpf.Trim(),
                dto.Email.Trim().ToLowerInvariant(),
                hashed,
                dto.Idade,
                true
            );

            var created = await _repo.AddAsync(usuario, ct);
            return _mapper.Map<UsuarioDto>(created);
        }


        public Task<UsuarioDto?> GetByIdAsync(int id, CancellationToken ct = default) {
            return _repo.GetByIdAsync(id, ct)
                .ContinueWith(t => t.Result is null ? null : _mapper.Map<UsuarioDto>(t.Result), ct);
        }

        public async Task<UsuarioDto?> GetByEmailAsync(string cpf, CancellationToken ct = default) {
            var u = await _repo.GetByCpfAsync(cpf, ct);
            return u == null ? null : _mapper.Map<UsuarioDto>(u);
        }

        public async Task<LoginResponseDto> LoginAsync(LoginDto dto, CancellationToken ct = default) {
            if (string.IsNullOrWhiteSpace(dto.Cpf) || string.IsNullOrWhiteSpace(dto.Senha))
                throw new ArgumentException("CPF e senha são obrigatórios.");

            var usuario = await _repo.GetByCpfAsync(dto.Cpf.Trim(), ct);
            if (usuario == null)
                throw new UnauthorizedAccessException("Usuário ou senha inválidos.");

            var senhaCorreta = BCrypt.Net.BCrypt.Verify(dto.Senha, usuario.SenhaHash);
            if (!senhaCorreta)
                throw new UnauthorizedAccessException("Usuário ou senha inválidos.");

            var (token, expiraEm) = _tokenService.GerarToken(usuario);

            await _logRepo.AddAsync(new LogLogin(usuario.Id, DateTime.UtcNow), ct);

            return new LoginResponseDto {
                Token = token,
                ExpiraEm = expiraEm,
                Nome = usuario.Nome,
                Cpf = usuario.Cpf
            };
        }

        public async Task<UsuarioDto?> AuthenticateAsync(string email, string senhaPlain, CancellationToken ct = default) {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senhaPlain))
                throw new ArgumentException("Email e senha são obrigatórios.");

            var usuario = await _repo.GetByCpfAsync(email.Trim().ToLowerInvariant(), ct);
            if (usuario == null)
                return null;

            var senhaCorreta = BCrypt.Net.BCrypt.Verify(senhaPlain, usuario.SenhaHash);
            if (!senhaCorreta)
                return null;

            return _mapper.Map<UsuarioDto>(usuario);
        }

        //TODO Finalizar o método abaixo
        //private async Task RegistrarLoginAsync(int usuarioId, string dispositivo, string ip, CancellationToken ct)
        //{
        //    var log = new LogLogin(usuarioId, DateTime.UtcNow);
        //    await _db.LogLogins.AddAsync(log, ct);
        //    await _db.SaveChangesAsync(ct);
        //}
    }
}
