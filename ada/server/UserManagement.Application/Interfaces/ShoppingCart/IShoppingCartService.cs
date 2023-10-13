using UserManagement.Application.Types.ShoppingCart;
using UserManagement.Domain.Interfaces;

namespace UserManagement.Application.Interfaces.ShoppingCart
{
    public interface IShoppingCartService<TEntity, TEntityId>: IReadableQuerable<TEntity, TEntityId>
    {
        Task<TEntity?> Delete(Guid userId, Guid productId);

        Task<TEntity> Add(ShoppingCartInputType shoppingCartInput);
    }
}
