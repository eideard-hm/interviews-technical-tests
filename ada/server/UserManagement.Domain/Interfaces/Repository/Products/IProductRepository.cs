namespace UserManagement.Domain.Interfaces.Repository.Products
{
    public interface IProductRepository<TEntity, TEntityId> : IReadableQuerable<TEntity, TEntityId>
    {
        IQueryable<TEntity> GetProductByUser(Guid userId);

        Task<TEntity> UpdateStock(TEntityId id, int quantitySold);
    }
}
