using Microsoft.EntityFrameworkCore;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Interfaces.Repository.ShoppingCart;
using UserManagement.Infrastructure.Context;

namespace UserManagement.Infrastructure.Repository.ShoppingCart
{
    public class ShoppingCartRepository : IShoppingCartRepository<UserProductDetail, Guid>
    {
        #region Fields

        private readonly UserManagementContext _context;

        #endregion

        #region Builders

        public ShoppingCartRepository(UserManagementContext context)
        {
            _context = context;
        }

        #endregion

        #region Public Methods

        public async Task<UserProductDetail> Add(UserProductDetail userProduct)
        {
            await _context.UserProductDetails.AddAsync(userProduct);
            await SaveChangesAsync();
            return userProduct;
        }

        public async Task<UserProductDetail?> Delete(Guid userId, Guid productId)
        {
            await _context.UserProductDetails
                  .Where(u => u.ProductId == productId && u.UserId == userId)
                  .ExecuteDeleteAsync();

            return null;
        }

        public IQueryable<UserProductDetail> GetAll()
        {
            return _context.UserProductDetails
                   .AsNoTracking();
        }

        public IQueryable<UserProductDetail> GetById(Guid id)
        {
            return _context.UserProductDetails
                   .Where(up => up.UserId == id)
                   .AsNoTracking();
        }

        public IQueryable<UserProductDetail> GetByPrimaryKey(Guid userId, Guid productId)
        {
            return _context.UserProductDetails
                   .Where(up => up.UserId == userId && up.ProductId == productId)
                   .AsNoTracking();
        }

        public async Task Edit(UserProductDetail userProduct)
        {
            await _context.UserProductDetails
                  .Where(up => up.UserId == userProduct.UserId && up.ProductId == userProduct.ProductId)
                  .ExecuteUpdateAsync(setters => setters
                    .SetProperty(up => up.QuantitySold, userProduct.QuantitySold )
                    .SetProperty(up => up.Total, userProduct.Total));
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}
