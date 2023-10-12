using UserManagement.Application.Interfaces.User;
using UserManagement.Application.Utils;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Interfaces.Repository.Users;

namespace UserManagement.Application.Services.Users
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

        public IQueryable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> GetAllAsync()
        {
            return _repository.GetAll();
        }

        public IQueryable<User?> GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public Task<User?> GetByIdentificationNumber(string identificationNumber)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
