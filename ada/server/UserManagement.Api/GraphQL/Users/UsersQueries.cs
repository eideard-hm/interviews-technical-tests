using UserManagement.Application.Services.Users;
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

        [UseProjection]
        [UseSorting]
        public IQueryable<User> GetUsers()
        {
            return _service.GetAllAsync();
        }

        [UseProjection]
        [UseFirstOrDefault]
        public IQueryable<User?> GetUserById(Guid userId)
        {
            return _service.GetById(userId);
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
