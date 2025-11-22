using Microsoft.AspNetCore.Mvc;
using NexFinance.src.Application.DTOs;
using NexFinance.src.Application.Interfaces;

namespace NexFinance.src.Api.Controllers {
    [ApiController]
    [Route("api/usuarios")]
    public class UsuarioController : ControllerBase {
        private readonly IUsuarioService _service;
        public UsuarioController(IUsuarioService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUsuarioDto dto, CancellationToken ct) {
            var created = await _service.CreateAsync(dto, ct);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id, CancellationToken ct) {
            var user = await _service.GetByIdAsync(id, ct);
            return user is null ? NotFound() : Ok(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto, CancellationToken ct) {
            var user = await _service.AuthenticateAsync(dto.Cpf, dto.Senha, ct);

            if (user is null)
                return Unauthorized();

            return Ok(user);
        }

    }
}
