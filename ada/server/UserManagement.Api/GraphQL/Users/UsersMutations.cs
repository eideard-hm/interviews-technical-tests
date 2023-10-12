using UserManagement.Api.GraphQL.Types;
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

        public async Task<User> Register(UserInputType userInput)
        {
            var user = new User
            {
                Address = userInput.Address,
                FullName = userInput.FullName,
                IdentificationNumber = userInput.IdentificationNumber,
                Password = userInput.Password,
                Phone = userInput.Phone,
                UserName = userInput.UserName
            };

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
