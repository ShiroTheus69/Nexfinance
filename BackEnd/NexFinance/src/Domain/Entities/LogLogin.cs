using global::NexFinance.Domain.Entities;
using System;

namespace NexFinance.src.Domain.Entities {
    
    public class LogLogin {
        public int Id { get; private set; }
        public int UsuarioId { get; private set; }
        public DateTime DataLogin { get; private set; }

        public Usuario Usuario { get; private set; }

        public LogLogin(int usuarioId, DateTime dataLogin) {
            UsuarioId = usuarioId;
            DataLogin = dataLogin;
        }
    }
}
