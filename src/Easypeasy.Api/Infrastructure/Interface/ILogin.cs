using Easypeasy.Api.Domain;

namespace Easypeasy.Api.Infrastructure.Interface
{
    public interface ILogin
    {
        User UserLogin(string username, string password);
        
    }
}
