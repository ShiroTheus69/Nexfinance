namespace NexFinance.Domain.Entities {
    public class Transferencia {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int ContaOrigemId { get; set; }
        public int ContaDestinoId { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

        public User Usuario { get; set; } = null!;
        public Conta ContaOrigem { get; set; } = null!;
        public Conta ContaDestino { get; set; } = null!;
    }
}
