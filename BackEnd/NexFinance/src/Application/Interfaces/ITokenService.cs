using NexFinance.Domain.Entities;
using System;

namespace NexFinance.src.Application.Interfaces {
    public interface ITokenService {
        (string Token, DateTime ExpiraEm) GerarToken(Usuario usuario);
    }
}
