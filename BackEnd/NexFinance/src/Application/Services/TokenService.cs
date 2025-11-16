using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NexFinance.Domain.Entities;
using NexFinance.src.Application.Interfaces;

namespace NexFinance.src.Application.Security {
    public class TokenService : ITokenService {
        private readonly IConfiguration _config;

        public TokenService(IConfiguration config) {
            _config = config;
        }

        public (string Token, DateTime ExpiraEm) GerarToken(Usuario usuario) {
            // Pega chave secreta do appsettings.json
            var secret = _config["Jwt:Key"];
            if (string.IsNullOrEmpty(secret))
                throw new InvalidOperationException("Chave JWT não configurada (Jwt:Key).");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Tempo de expiração (2h)
            var expira = DateTime.UtcNow.AddHours(2);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, usuario.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                new Claim(JwtRegisteredClaimNames.UniqueName, usuario.Nome)
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: expira,
                signingCredentials: creds
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return (tokenString, expira);
        }
    }
}
