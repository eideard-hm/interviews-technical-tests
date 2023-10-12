using UserManagement.Domain.Interfaces;

namespace UserManagement.Application.Interfaces
{
    internal interface IUserService<TEntity, TEntityId>: IAdd<TEntity>, IReadableQuerable<TEntity, TEntityId>
    {
    }
}
