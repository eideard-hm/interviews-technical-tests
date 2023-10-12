using UserManagement.Application.Interfaces.Auth;
using UserManagement.Application.Types.Auth;
using UserManagement.Application.Utils;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Interfaces.Repository.Users;

namespace UserManagement.Application.Services.Auth
{
    public class AuthService : IAuthService<User>
    {
        #region Fields

        private readonly IUserRepository<User, Guid> _repository;

        #endregion

        #region Builders

        public AuthService(IUserRepository<User, Guid> repository)
        {
            _repository = repository;
        }

        #endregion

        #region Public Methods

        public async Task<User?> VerifyLogin(LoginInputType loginInput) 
        {
            // verificar si la identificación y la contraseñas no son nulos
            if(loginInput is null)
            {
                throw new ArgumentNullException(string.Format("El número de identificación y la contraseña son requeridos!"));
            }

            // verificar si existe algun correo
            var user = await _repository.GetByIdentificationNumber(loginInput.IdentificationNumber) ?? throw new ApplicationException("Usuario o contraseña no son correctos!");

            // compare passwords
            var passwordsMatch = CustomBCrypt.ComparePasswords(loginInput.Password, user?.Password ?? string.Empty);

            if(!passwordsMatch)
            {
                throw new ApplicationException("Usuario o contraseña no son correctos!");
            }

            return user;
        }

        #endregion
    }
}
