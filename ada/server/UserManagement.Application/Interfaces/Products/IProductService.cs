namespace UserManagement.Application.Interfaces.Products
{
    internal interface IProductService<TEntity>
    {
        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> GetProductByUser(Guid userId);
    }
}
