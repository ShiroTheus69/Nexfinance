using System;
using System.Collections.Generic;

namespace NexFinance.Domain.Entities {
    public class Usuario {
        public int Id { get; private set; }
        public string Nome { get; private set; } = string.Empty;
        public string Cpf { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public byte[] SenhaHash { get; private set; } = Array.Empty<byte>();
        public int? Idade { get; private set; }
        public DateTime DtCriacao { get; private set; } = DateTime.UtcNow;

        private readonly List<Conta> _contas = new();
        public IReadOnlyCollection<Conta> Contas => _contas.AsReadOnly();

        private readonly List<Lancamento> _lancamentos = new();
        public IReadOnlyCollection<Lancamento> Lancamentos => _lancamentos.AsReadOnly();

        private readonly List<Transferencia> _transferencias = new();
        public IReadOnlyCollection<Transferencia> Transferencias => _transferencias.AsReadOnly();

        protected Usuario() { }

        public Usuario(string nome, string cpf, string email, byte[] senhaHash, int? idade) {
            SetNome(nome);
            SetCpf(cpf);
            SetEmail(email);
            SetSenha(senhaHash);
            Idade = idade;
        }

        public void SetNome(string nome) {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome inválido.");
            Nome = nome.Trim();
        }

        public void SetCpf(string cpf) {
            if (string.IsNullOrWhiteSpace(cpf) || cpf.Length != 11)
                throw new ArgumentException("CPF inválido.");
            Cpf = cpf.Trim();
        }

        public void SetEmail(string email) {
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
                throw new ArgumentException("E-mail inválido.");
            Email = email.Trim().ToLowerInvariant();
        }

        public void SetSenha(byte[] senhaHash) {
            if (senhaHash == null || senhaHash.Length == 0)
                throw new ArgumentException("Senha inválida.");
            SenhaHash = senhaHash;
        }
    }
}
