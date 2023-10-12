using UserManagement.Application.Services.Auth;
using UserManagement.Application.Types.Auth;
using UserManagement.Domain.Entities;
using UserManagement.Infrastructure.Context;
using UserManagement.Infrastructure.Repository;

namespace UserManagement.Api.GraphQL.Auth
{
    [ExtendObjectType(OperationTypeNames.Mutation)]
    public class AuthMutations
    {
        #region Fields

        private readonly AuthService _service;

        #endregion

        #region Builders

        public AuthMutations()
        {
            _service = CreateService();
        }

        #endregion

        #region Public Methods

        public async Task<User?> Login(LoginInputType loginInputType)
        {
            return await _service.VerifyLogin(loginInputType);
        }

        #endregion

        #region Private Methods

        private static AuthService CreateService()
        {
            UserManagementContext db = new();
            UserRepository repository = new(db);
            return new(repository);
        }

        #endregion
    }
}
