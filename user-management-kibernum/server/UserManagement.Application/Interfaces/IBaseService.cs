using UserManagement.Domain.Interfaces;

namespace UserManagement.Application.Interfaces
{
    public interface IBaseService<TEntity, TEntityId>:
        IAdd<TEntity>, IEdit<TEntity>, IDelete<TEntityId>, IReadable<TEntity, TEntityId>
    {
    }
}
