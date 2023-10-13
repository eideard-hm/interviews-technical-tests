namespace UserManagement.Application.Interfaces.Products
{
    internal interface IProductService<TEntity, TEntityId>
    {
        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> GetProductByUser(Guid userId);

        Task<TEntity> UpdateStock(TEntityId id, int quantitySold);
    }
}
