using UserManagement.Application.Services;
using UserManagement.Domain.Entities;
using UserManagement.Infrastructure.Context;
using UserManagement.Infrastructure.Repository;

namespace UserManagement.Api.GraphQL.Users
{
    [ExtendObjectType(OperationTypeNames.Query)]
    public class UsersQueries
    {
        #region Fields

        private readonly UserService _service;

        #endregion

        #region Builders

        public UsersQueries()
        {
            _service = CreateService();
        }

        #endregion

        #region Public Methods

        public async Task<List<User>> GetUsers()
        {
            return await _service.GetAllAsync();
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
