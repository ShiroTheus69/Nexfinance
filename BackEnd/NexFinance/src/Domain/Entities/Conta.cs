namespace NexFinance.Domain.Entities {
    public class Conta {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;

        public ICollection<Lancamento>? Lancamentos { get; set; }
        public ICollection<Transferencia>? TransferenciasOrigem { get; set; }
        public ICollection<Transferencia>? TransferenciasDestino { get; set; }
    }
}
