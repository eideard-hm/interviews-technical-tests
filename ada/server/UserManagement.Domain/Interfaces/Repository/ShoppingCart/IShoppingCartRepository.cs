namespace UserManagement.Domain.Interfaces.Repository.ShoppingCart
{
    public interface IShoppingCartRepository<TEntity, TEntityId> : IAdd<TEntity>, IReadableQuerable<TEntity, TEntityId>, ITransacction, IEdit<TEntity>
    {
        Task<TEntity?> Delete(Guid userId, Guid productId);

        IQueryable<TEntity?> GetByPrimaryKey(Guid userId, Guid productId);

    }
}
