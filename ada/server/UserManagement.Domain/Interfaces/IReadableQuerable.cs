namespace UserManagement.Domain.Interfaces
{
    public interface IReadableQuerable<TEntity, TEntityId>
    {
        IQueryable<TEntity> GetAll();

        IQueryable<TEntity?> GetById(TEntityId id);
    }
}
