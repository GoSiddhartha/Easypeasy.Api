using Easypeasy.Api.Infrastructure.Domain;

namespace Easypeasy.Api.Infrastructure.Service.Interface
{
    public interface ILoginService
    {
        User UserLogin(string username, string password);

    }
}
