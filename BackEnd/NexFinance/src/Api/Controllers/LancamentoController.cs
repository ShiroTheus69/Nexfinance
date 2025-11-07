using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NexFinance.Domain.Entities;
using NexFinance.Infrastructure.Context;

namespace NexFinance.Api.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class LancamentoController : ControllerBase {
        private readonly NexFinanceDbContext _context;
        public LancamentoController(NexFinanceDbContext context) => _context = context;

        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var lancamentos = await _context.Lancamentos
                .Include(l => l.Usuario)
                .Include(l => l.Categoria)
                .Include(l => l.Conta)
                .ToListAsync();
            return Ok(lancamentos);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Lancamento lancamento) {
            _context.Lancamentos.Add(lancamento);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAll), new { id = lancamento.Id }, lancamento);
        }
    }
}
