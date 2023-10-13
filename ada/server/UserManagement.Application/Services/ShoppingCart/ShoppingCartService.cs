using UserManagement.Application.Interfaces.ShoppingCart;
using UserManagement.Application.Types.ShoppingCart;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Interfaces.Repository.Products;
using UserManagement.Domain.Interfaces.Repository.ShoppingCart;

namespace UserManagement.Application.Services.ShoppingCart
{
    public class ShoppingCartService : IShoppingCartService<UserProductDetail, Guid>
    {
        #region Fields

        private readonly IShoppingCartRepository<UserProductDetail, Guid> _repository;
        private readonly IProductRepository<Product, Guid> _productRepository;

        #endregion

        #region Builders

        public ShoppingCartService(
            IShoppingCartRepository<UserProductDetail, Guid> repository,
            IProductRepository<Product, Guid> productRepository
            )
        {
            _repository = repository;
            _productRepository = productRepository;
        }

        #endregion

        #region Public Methods

        public async Task<UserProductDetail> Add(ShoppingCartInputType shoppingCart)
        {
            if (shoppingCart == null)
            {
                throw new ArgumentNullException(string.Format("El 'Carrito de Compras' es requerido!"));
            }

            var product = _productRepository.GetById(shoppingCart.ProductId).FirstOrDefault() ?? throw new ApplicationException("El producto no existe!");

            var currentShoppingCart = _repository.GetByPrimaryKey(shoppingCart.UserId, shoppingCart.ProductId).FirstOrDefault();

            // actualizar el stock
            await _productRepository.UpdateStock(product.Id, shoppingCart.QuantitySold);

            if (currentShoppingCart == null)
            {
                UserProductDetail userProduct = new()
                {
                    ProductId = shoppingCart.ProductId,
                    UserId = shoppingCart.UserId,
                    QuantitySold = shoppingCart.QuantitySold,
                    UnitPrice = product.Price,
                    Total = product.Price * shoppingCart.QuantitySold
                };

                return await _repository.Add(userProduct);
            }

            currentShoppingCart.QuantitySold += shoppingCart.QuantitySold;
            currentShoppingCart.Total += (product.Price * shoppingCart.QuantitySold);


            await _repository.Edit(currentShoppingCart);
            return currentShoppingCart;
        }

        public async Task<UserProductDetail?> Delete(Guid userId, Guid productId)
        {
            if (userId == Guid.Empty || productId == Guid.Empty)
            {
                throw new ArgumentNullException("El id del usuario y del producto son requerido!");
            }

            return await _repository.Delete(userId, productId);
        }

        public IQueryable<UserProductDetail> GetAll()
        {
            return _repository.GetAll();
        }

        public IQueryable<UserProductDetail?> GetById(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException("El id del usuario es requerido!");
            }

            return _repository.GetById(id);
        }

        #endregion
    }
}
