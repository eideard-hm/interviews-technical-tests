namespace UserManagement.Domain.Interfaces
{
    public interface IReadableQuerable<TEntity, TEntityId>
    {
        IQueryable<TEntity> GetAllAsync();

        IQueryable<TEntity> GetByIdAsync(TEntityId id);
    }
}
