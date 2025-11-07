using NexFinance.Domain.Enums;

namespace NexFinance.Domain.Entities {
    public class Lancamento {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int CategoriaId { get; set; }
        public int ContaId { get; set; }
        public TipoMovimento Tipo { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

        public User Usuario { get; set; } = null!;
        public Categoria Categoria { get; set; } = null!;
        public Conta Conta { get; set; } = null!;
    }
}
