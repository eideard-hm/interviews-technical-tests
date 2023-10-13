using UserManagement.Application.Services.ShoppingCart;
using UserManagement.Application.Types.ShoppingCart;
using UserManagement.Domain.Entities;
using UserManagement.Infrastructure.Context;
using UserManagement.Infrastructure.Repository.Products;
using UserManagement.Infrastructure.Repository.ShoppingCart;

namespace UserManagement.Api.GraphQL.ShoppingCart
{
    [ExtendObjectType(OperationTypeNames.Mutation)]
    public class ShoppingCartMutations
    {
        #region Fields

        private readonly ShoppingCartService _service;

        #endregion

        #region Builders

        public ShoppingCartMutations()
        {
            _service = CreateService();
        }

        #endregion

        #region Public Methods

        public async Task<UserProductDetail> AddProductToShoppingCart(ShoppingCartInputType shoppingCartInput)
        {
            return await _service.Add(shoppingCartInput);
        }

        #endregion

        #region Private Methods

        private static ShoppingCartService CreateService()
        {
            UserManagementContext db = new();
            ShoppingCartRepository repository = new(db);
            ProductRepository productRepository = new(db);
            return new(repository, productRepository);
        }

        #endregion
    }
}
