using UserManagement.Application.Types.Auth;

namespace UserManagement.Application.Interfaces.Auth
{
    public interface IAuthService<TEntity>
    {
        Task<TEntity?> VerifyLogin(LoginInputType loginInput);
    }
}
