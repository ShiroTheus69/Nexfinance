using NexFinance.Domain.Enums;

namespace NexFinance.Domain.Entities {
    public class Lancamento {
        public int Id { get; private set; }
        public int UsuarioId { get; private set; }
        public int CategoriaId { get; private set; }
        public int ContaId { get; private set; }
        public TipoMovimento Tipo { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime Data { get; private set; }
        public string? Descricao { get; private set; }
        public DateTime DataCriacao { get; private set; } = DateTime.UtcNow;

        public Usuario Usuario { get; private set; } = null!;
        public Categoria Categoria { get; private set; } = null!;
        public Conta Conta { get; private set; } = null!;

        protected Lancamento() { }

        public Lancamento(int usuarioId, int categoriaId, int contaId, TipoMovimento tipo, decimal valor, DateTime data, string? descricao) {
            SetUsuario(usuarioId);
            SetCategoria(categoriaId);
            SetConta(contaId);
            SetTipo(tipo);
            SetValor(valor);
            SetData(data);
            Descricao = descricao;
        }

        public void SetUsuario(int usuarioId) => UsuarioId = usuarioId > 0 ? usuarioId : throw new ArgumentException("Usuário inválido.");
        public void SetCategoria(int categoriaId) => CategoriaId = categoriaId > 0 ? categoriaId : throw new ArgumentException("Categoria inválida.");
        public void SetConta(int contaId) => ContaId = contaId > 0 ? contaId : throw new ArgumentException("Conta inválida.");
        public void SetTipo(TipoMovimento tipo) => Tipo = tipo;
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
