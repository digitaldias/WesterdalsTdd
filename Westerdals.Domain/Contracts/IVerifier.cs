namespace Westerdals.Domain.Contracts
{
    public interface IVerifier<TEntity>
    {
        bool IsValid(TEntity entity);
    }
}
