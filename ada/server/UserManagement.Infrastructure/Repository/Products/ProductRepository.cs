using Microsoft.EntityFrameworkCore;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Interfaces.Repository.Products;
using UserManagement.Infrastructure.Context;

namespace UserManagement.Infrastructure.Repository.Products
{
    public class ProductRepository : IProductRepository<Product>
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

        public IQueryable<Product> GetProductByUser(Guid userId)
        {
            return _context.Products
                   .Where(p => p.UserProductDetails
                                .Any(up => up.UserId == userId))
                   .AsNoTracking();
        }

        #endregion
    }
}
