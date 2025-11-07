namespace NexFinance.Domain.Entities {
    public class User {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string SenhaHash { get; set; } = string.Empty;
        public int? Idade { get; set; }
        public DateTime DtCriacao { get; set; } = DateTime.UtcNow;

        public ICollection<Lancamento>? Lancamentos { get; set; }
        public ICollection<Transferencia>? Transferencias { get; set; }
    }
}
