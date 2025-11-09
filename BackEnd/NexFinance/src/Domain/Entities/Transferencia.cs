namespace NexFinance.Domain.Entities {
    public class Transferencia {
        public int Id { get; private set; }
        public int UsuarioId { get; private set; }
        public int ContaOrigemId { get; private set; }
        public int ContaDestinoId { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime Data { get; private set; }
        public string? Descricao { get; private set; }
        public DateTime DataCriacao { get; private set; } = DateTime.UtcNow;

        public Usuario Usuario { get; private set; } = null!;
        public Conta ContaOrigem { get; private set; } = null!;
        public Conta ContaDestino { get; private set; } = null!;

        protected Transferencia() { }

        public Transferencia(int usuarioId, int contaOrigemId, int contaDestinoId, decimal valor, DateTime data, string? descricao) {
            SetUsuario(usuarioId);
            SetContas(contaOrigemId, contaDestinoId);
            SetValor(valor);
            SetData(data);
            Descricao = descricao;
        }

        public void SetUsuario(int usuarioId) => UsuarioId = usuarioId > 0 ? usuarioId : throw new ArgumentException("Usuário inválido.");
        public void SetContas(int origem, int destino) {
            if (origem == destino)
                throw new ArgumentException("Contas de origem e destino devem ser diferentes.");
            ContaOrigemId = origem;
            ContaDestinoId = destino;
        }
        public void SetValor(decimal valor) {
            if (valor <= 0)
                throw new ArgumentException("Valor deve ser maior que zero.");
            Valor = valor;
        }
        public void SetData(DateTime data) {
            if (data == default)
                throw new ArgumentException("Data inválida.");
            Data = DateTime.SpecifyKind(data, DateTimeKind.Utc);
        }
    }
}
