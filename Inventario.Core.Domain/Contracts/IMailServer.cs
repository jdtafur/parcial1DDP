namespace Inventario.Core.Domain.Contracts
{
    public interface IMailServer
    {
        string Send(string message, string email);
    }
}