namespace UserManagement.Domain.Interfaces
{
    public interface IEdit<TEntity>
    {
        Task Edit(TEntity entity);
    }
}
