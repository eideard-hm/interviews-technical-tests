using UserManagement.Application.Interfaces;
using UserManagement.Application.Utils;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Interfaces.Repository.Users;

namespace UserManagement.Application.Services
{
    public class UserService : IUserService<User, Guid>
    {

        #region Fields

        private readonly IUserRepository<User, Guid> _repository;

        #endregion

        #region Builders

        public UserService(IUserRepository<User, Guid> repository)
        {
            _repository = repository;
        }

        #endregion

        #region Public Methods

        public async Task<User> Add(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(string.Format("El 'Usuario' es requerido!"));
            }

            user.Password = CustomBCrypt.HashPassword(user.Password);

            return await _repository.Add(user);
        }

        public IQueryable<User> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public IQueryable<User> GetByIdAsync(Guid id)
        {
            return _repository.GetByIdAsync(id);
        }

        #endregion
    }
}
