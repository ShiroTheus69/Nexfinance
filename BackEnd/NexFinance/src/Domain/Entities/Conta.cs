namespace NexFinance.Domain.Entities {
    public class Conta {
        public int Id { get; private set; }
        public string Nome { get; private set; } = string.Empty;
        public string Tipo { get; private set; } = string.Empty;

        public int UsuarioId { get; private set; }

        public Usuario Usuario {  get; private set; }

        private readonly List<Lancamento> _lancamentos = new();
        public IReadOnlyCollection<Lancamento> Lancamentos => _lancamentos.AsReadOnly();

        private readonly List<Transferencia> _transferenciasOrigem = new();
        public IReadOnlyCollection<Transferencia> TransferenciasOrigem => _transferenciasOrigem.AsReadOnly();

        private readonly List<Transferencia> _transferenciasDestino = new();
        public IReadOnlyCollection<Transferencia> TransferenciasDestino => _transferenciasDestino.AsReadOnly();

        protected Conta() { }

        public Conta(string nome, string tipo, int idUsuario) {
            SetNome(nome);
            SetTipo(tipo);
            SetUsuario(idUsuario);
        }

        public void SetNome(string nome) {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome inválido.");
            Nome = nome;
        }

        public void SetTipo(string tipo) {
            if (string.IsNullOrWhiteSpace(tipo))
                throw new ArgumentException("Tipo inválido.");
            Tipo = tipo;
        }

        public void SetUsuario(int usuarioId) => UsuarioId = usuarioId > 0 ? usuarioId : throw new ArgumentException("Usuário inválido.");
    }
}
