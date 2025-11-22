using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using NexFinance.src.Application.DTOs;
using NexFinance.src.Application.DTOs.Auth;
using NexFinance.src.Application.Interfaces;
using NexFinance.src.Application.Interfaces.Repositories;
using NexFinance.src.Application.Security;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NexFinance.src.Application.Services {

    public class AuthService : IAuthService {
        private readonly IUsuarioRepository _usuarioRepo;
        private readonly IMapper _mapper;
        private readonly IConfiguration _cfg;

        public AuthService(IUsuarioRepository usuarioRepo, IMapper mapper, IConfiguration cfg) {
            _usuarioRepo = usuarioRepo;
            _mapper = mapper;
            _cfg = cfg;
        }

        public async Task<LoginResponseDto?> AuthenticateAsync(LoginDto dto, CancellationToken ct = default) {

            var user = await _usuarioRepo.GetByCpfAsync(dto.Cpf, ct);
            if (user == null)
                return null;

            if (!PasswordHasher.Verify(dto.Senha, user.SenhaHash))
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_cfg["Jwt:Key"]);

            var claims = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim("cpf", user.Cpf),
                new Claim(ClaimTypes.Name, user.Nome)
            });

            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = claims,
                Expires = DateTime.UtcNow.AddHours(4),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature),
                Issuer = _cfg["Jwt:Issuer"],
                Audience = _cfg["Jwt:Audience"]
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new LoginResponseDto {
                Token = tokenHandler.WriteToken(token),
                ExpiraEm = tokenDescriptor.Expires.GetValueOrDefault(),
                Nome = user.Nome,
                Cpf = user.Cpf,
                Role = ""
            };
        }
    }
}
