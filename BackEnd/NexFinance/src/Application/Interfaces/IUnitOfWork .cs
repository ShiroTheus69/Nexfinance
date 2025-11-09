using NexFinance.src.Application.Interfaces.Repositories;

namespace NexFinance.src.Application.Interfaces {
    public interface IUnitOfWork : IDisposable {
        ILancamentoRepository Lancamentos { get; }
        IContaRepository Contas { get; }
        ICategoriaRepository Categorias { get; }
        IUsuarioRepository Usuarios { get; }
        ITransferenciaRepository Transferencias { get; }

        Task<int> SaveChangesAsync(CancellationToken ct = default);
    }

}
