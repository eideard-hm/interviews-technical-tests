namespace UserManagement.Domain.Interfaces.Repository.Products
{
    public interface IProductRepository<TEntity>
    {
        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> GetProductByUser(Guid userId);
    }
}
