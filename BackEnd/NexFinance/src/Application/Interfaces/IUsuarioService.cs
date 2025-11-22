using NexFinance.src.Application.DTOs;

namespace NexFinance.src.Application.Interfaces {
    public interface IUsuarioService {
        Task<UsuarioDto> CreateAsync(CreateUsuarioDto dto, CancellationToken ct = default);
        Task<UsuarioDto?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<UsuarioDto?> AuthenticateAsync(string cpf, string senha, CancellationToken ct);


    }
}
