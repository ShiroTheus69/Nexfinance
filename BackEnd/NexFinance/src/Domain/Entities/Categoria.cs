using NexFinance.Domain.Enums;

namespace NexFinance.Domain.Entities {
    public class Categoria {
        public int Id { get; private set; }
        public string Nome { get; private set; } = string.Empty;
        public TipoMovimento Tipo { get; private set; }
        public string? Descricao { get; private set; }

        private readonly List<Lancamento> _lancamentos = new();
        public IReadOnlyCollection<Lancamento> Lancamentos => _lancamentos.AsReadOnly();

        protected Categoria() { }

        public Categoria(string nome, TipoMovimento tipo, string? descricao) {
            SetNome(nome);
            Tipo = tipo;
            Descricao = descricao;
        }

        public void SetNome(string nome) {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome da categoria inválido.");
            Nome = nome.Trim();
        }
    }
}
