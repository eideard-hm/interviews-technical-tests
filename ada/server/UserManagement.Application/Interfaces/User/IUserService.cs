using UserManagement.Domain.Interfaces;

namespace UserManagement.Application.Interfaces.User
{
    internal interface IUserService<TEntity, TEntityId> : IAdd<TEntity>, IReadableQuerable<TEntity, TEntityId>
    {
    }
}
