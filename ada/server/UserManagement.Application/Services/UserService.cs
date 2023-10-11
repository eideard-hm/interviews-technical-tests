using UserManagement.Application.Interfaces;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Interfaces.Repository;

namespace UserManagement.Application.Services
{
    public class UserService : IUserService<User, Guid>
    {

        #region Fields

        private readonly IBaseRepository<User, Guid> _repository;

        #endregion

        #region Builders

        public UserService(IBaseRepository<User, Guid> repository)
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

            return await _repository.Add(user);
        }

        public async Task Edit(User user)
        {
            if (user is null)
            {
                throw new ArgumentNullException(string.Format("Se debe de enviar el 'Usuario' que quiere editar!"));
            }

            await _repository.Edit(user);
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        #endregion
    }
}
