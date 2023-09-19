using UserManagement.Application.Services;
using UserManagement.Domain.Entities;
using UserManagement.Infrastructure.Context;
using UserManagement.Infrastructure.Repository;

namespace UserManagement.Api.GraphQL.Users
{
    [ExtendObjectType(OperationTypeNames.Mutation)]
    public class UsersMutations
    {
        #region Fields

        private readonly UserService _service;

        #endregion

        #region Builders

        public UsersMutations()
        {
            _service = CreateService();
        }

        #endregion

        #region Public Methods

        public async Task<User> CreateUser(User user)
        {
            return await _service.Add(user);
        }

        #endregion

        #region Private Methods

        private static UserService CreateService()
        {
            UserManagementContext db = new();
            UserRepository repository = new(db);
            return new(repository);
        }

        #endregion
    }
}
