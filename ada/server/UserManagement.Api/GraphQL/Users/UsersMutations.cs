﻿using UserManagement.Api.GraphQL.Types.Users;
using UserManagement.Application.Enums;
using UserManagement.Application.Services.Users;
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
            User user = new()
            {
                Address = userInput.Address,
                FullName = userInput.FullName,
                IdentificationNumber = userInput.IdentificationNumber,
                Password = userInput.Password,
                Phone = userInput.Phone,
                UserName = userInput.UserName,
                UserProfile = userInput.UserProfile
            };

            Console.WriteLine(user.UserProfile);

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
