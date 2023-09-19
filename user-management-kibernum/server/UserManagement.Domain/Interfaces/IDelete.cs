namespace UserManagement.Domain.Interfaces
{
    public interface IDelete<TEntityId>
    {
        Task Delete(TEntityId id);
    }
}
