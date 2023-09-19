using Microsoft.EntityFrameworkCore;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Interfaces.Repository;
using UserManagement.Infrastructure.Context;

namespace UserManagement.Infrastructure.Repository
{
    public class UserRepository : IBaseRepository<User, Guid>
    {
        #region Fields

        private readonly UserManagementContext _context;

        #endregion

        #region Builders

        public UserRepository(UserManagementContext context)
        {
            _context = context;
        }


        #endregion

        #region Public Methods

        public async Task<User> Add(User user)
        {
            await _context.Users.AddAsync(user);
            await SaveChangesAsync();
            return user;
        }

        public async Task Delete(Guid id)
        {
            await _context.Users
                  .Where(u => u.Id == id)
                  .ExecuteDeleteAsync();
        }

        public async Task Edit(User user)
        {
            await _context.Users
                  .Where(u => u.Id == user.Id)
                  .ExecuteUpdateAsync(setters => setters
                    .SetProperty(u => u.Account, user.Account)
                    .SetProperty(u => u.Password, user.Password)
                    .SetProperty(u => u.Type, user.Type)
                    .SetProperty(u => u.Status, user.Status));
        }

        public Task<List<User>> GetAllAsync()
        {
            return _context.Users
                   .AsNoTracking()
                   .ToListAsync();
        }

        public Task<User> GetByIdAsync(Guid id)
        {
            return _context.Users
                   .AsNoTracking()
                   .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }

    #endregion
}

