using UserManagement.Application.Interfaces.Products;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Interfaces.Repository.Products;

namespace UserManagement.Application.Services.Products
{
    public class ProductService : IProductService<Product, Guid>
    {
        #region Fields

        private readonly IProductRepository<Product, Guid> _repository;

        #endregion

        #region Builders

        public ProductService(IProductRepository<Product, Guid> repository)
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

        public async Task<Product> UpdateStock(Guid id, int quantitySold)
        {
            if(id == Guid.Empty)
            {
                throw new ArgumentNullException("El id del producto no es válido");
            }

            return await _repository.UpdateStock(id, quantitySold);
        }

        #endregion
    }
}
