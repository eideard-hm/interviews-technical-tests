using UserManagement.Application.Services.Products;
using UserManagement.Application.Services.Users;
using UserManagement.Domain.Entities;
using UserManagement.Infrastructure.Context;
using UserManagement.Infrastructure.Repository;
using UserManagement.Infrastructure.Repository.Products;

namespace UserManagement.Api.GraphQL.Products
{
    [ExtendObjectType(OperationTypeNames.Query)]
    public class ProductQueries
    {
        #region Fields

        private readonly ProductService _service;

        #endregion


        #region Builders

        public ProductQueries()
        {
            _service = CreateService();
        }

        #endregion


        #region Public Methods

        [UseProjection]
        public IQueryable<Product> AllProducts()
        {
            return _service.GetAll();
        }

        [UseProjection]
        public IQueryable<Product> UserShopping(Guid userId)
        {
            return _service.GetProductByUser(userId);
        }

        #endregion


        #region Private Methods

        private static ProductService CreateService()
        {
            UserManagementContext db = new();
            ProductRepository repository = new(db);
            return new(repository);
        }

        #endregion

    }
}
