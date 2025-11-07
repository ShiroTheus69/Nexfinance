using NexFinance.Domain.Enums;

namespace NexFinance.Domain.Entities {
    public class Categoria {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public TipoCategoria Tipo { get; set; } // ENTRADA ou SAIDA
        public string? Descricao { get; set; }

        public ICollection<Lancamento>? Lancamentos { get; set; }
    }
}
