namespace Inventario.Core.Domain.Contracts
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}