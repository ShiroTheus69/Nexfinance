using Microsoft.AspNetCore.Mvc;
using NexFinance.src.Application.DTOs;
using NexFinance.src.Application.Interfaces;

namespace NexFinance.src.Api.Controllers {
    [ApiController]
    [Route("api/Contas")]
    public class ContaController : ControllerBase {
        private readonly IContaService _service;
        public ContaController(IContaService service) => _service = service;

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id, CancellationToken ct) {
            var dto = await _service.GetByIdAsync(id, ct);
            return dto == null ? NotFound() : Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateContaDto dto, CancellationToken ct) {
            var created = await _service.CreateAsync(dto, ct);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        //[HttpGet("usuario/{usuarioId:int}")]
        //public async Task<IActionResult> GetByUsuario(int usuarioId, int page = 1, int pageSize = 20, CancellationToken ct = default) {
        //    var (items, total) = await _service.GetByUsuarioPagedAsync(usuarioId, page, pageSize, ct);
        //    return Ok(new { items, total });
        //}
    }

}
