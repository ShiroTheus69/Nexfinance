using NexFinance.src.Application.DTOs.Auth;
using NexFinance.src.Application.DTOs;

namespace NexFinance.src.Application.Interfaces {
    public interface IAuthService {
        Task<LoginResponseDto?> AuthenticateAsync(LoginDto dto, CancellationToken ct = default);
    }
}
