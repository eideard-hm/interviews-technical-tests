namespace UserManagement.Domain.Interfaces.Repository.Users
{
    public interface IUserRepository<TEntity, TEntityId> :
        IAdd<TEntity>, IReadableQuerable<TEntity, TEntityId>, ITransacction
    {
    }
}
