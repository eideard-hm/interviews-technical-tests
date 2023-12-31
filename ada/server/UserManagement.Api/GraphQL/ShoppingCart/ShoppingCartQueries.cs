﻿using UserManagement.Application.Services.ShoppingCart;
using UserManagement.Domain.Entities;
using UserManagement.Infrastructure.Context;
using UserManagement.Infrastructure.Repository.Products;
using UserManagement.Infrastructure.Repository.ShoppingCart;

namespace UserManagement.Api.GraphQL.ShoppingCart
{
    [ExtendObjectType(OperationTypeNames.Query)]
    public class ShoppingCartQueries
    {
        #region Fields

        private readonly ShoppingCartService _service;

        #endregion

        #region Builders

        public ShoppingCartQueries()
        {
            _service = CreateService();
        }

        #endregion

        #region  Public Methods

        [UseProjection]
        [UseSorting]
        public IQueryable<UserProductDetail> GetUsersShopping()
        {
            return _service.GetAll();
        }

        [UseProjection]
        [UseSorting]
        public IQueryable<UserProductDetail?> GetUserShoppingCart(Guid userId)
        {
            return _service.GetById(userId);
        }


        #endregion

        #region Private Methods

        private static ShoppingCartService CreateService()
        {
            UserManagementContext db = new();
            ShoppingCartRepository repository = new(db);
            ProductRepository productRepository = new(db);
            return new(repository, productRepository);
        }

        #endregion
    }
}
