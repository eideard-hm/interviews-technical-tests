using UserManagement.Application.Interfaces.Products;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Interfaces.Repository.Products;

namespace UserManagement.Application.Services.Products
{
    public class ProductService : IProductService<Product>
    {
        #region Fields

        private readonly IProductRepository<Product> _repository;

        #endregion

        #region Builders

        public ProductService(IProductRepository<Product> repository)
        {
            _repository = repository;
        }

        #endregion

        #region Public Methods

        public IQueryable<Product> GetAll()
        {
            return _repository.GetAll();
        }

        public IQueryable<Product> GetProductByUser(Guid userId)
        {
            return _repository.GetProductByUser(userId);
        }

        #endregion
    }
}
