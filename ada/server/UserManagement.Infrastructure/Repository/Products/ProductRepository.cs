using Microsoft.EntityFrameworkCore;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Interfaces.Repository.Products;
using UserManagement.Infrastructure.Context;

namespace UserManagement.Infrastructure.Repository.Products
{
    public class ProductRepository : IProductRepository<Product, Guid>
    {
        #region Fields
        
        private readonly UserManagementContext _context;

        #endregion


        #region Builders

        public ProductRepository(UserManagementContext context)
        {
            _context = context;
        }

        #endregion


        #region Public Methods

        public IQueryable<Product> GetAll()
        {
            return _context.Products
                   .AsNoTracking();
        }

        public IQueryable<Product> GetById(Guid id)
        {
            return _context.Products
                   .Where(p => p.Id == id)
                   .AsNoTracking();
        }

        public IQueryable<Product> GetProductByUser(Guid userId)
        {
            return _context.Products
                   .Where(p => p.UserProductDetails
                                .Any(up => up.UserId == userId))
                   .AsNoTracking();
        }

        public async Task<Product> UpdateStock(Guid id, int quantitySold)
        {
            await _context.Products
                  .Where(p => p.Id == id)
                  .ExecuteUpdateAsync(setters => setters.SetProperty(p => p.Stock, p => p.Stock - quantitySold));

            return new Product { Id = id };
        }

        #endregion
    }
}
