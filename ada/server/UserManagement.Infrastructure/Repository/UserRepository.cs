using Microsoft.EntityFrameworkCore;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Interfaces.Repository.Users;
using UserManagement.Infrastructure.Context;

namespace UserManagement.Infrastructure.Repository
{
    public class UserRepository : IUserRepository<User, Guid>
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

        public IQueryable<User> GetAll()
        {
            return _context.Users
                   .AsNoTracking();
        }

        public IQueryable<User?> GetById(Guid id)
        {
            return _context.Users
                   .Where(u => u.Id == id)
                   .AsNoTracking();
        }

        public async Task<User?> GetByIdentificationNumber(string identificationNumber)
        {
            return await _context.Users
                         .Where(u => u.IdentificationNumber == identificationNumber)
                         .AsNoTracking()
                         .FirstOrDefaultAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }

    #endregion
}

