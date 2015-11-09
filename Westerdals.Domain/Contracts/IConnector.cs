namespace Westerdals.Domain.Contracts
{
    public interface IConnector
    {
        bool Connect();

        void AddToTable<T>(T entityToAdd);
    }
}
