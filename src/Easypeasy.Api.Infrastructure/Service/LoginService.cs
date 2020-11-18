using Easypeasy.Api.Infrastructure.Domain;
using Easypeasy.Api.Infrastructure.Service.Interface;

namespace Easypeasy.Api.Infrastructure.Service
{
    public class LoginService : ILoginService
    {
        public User UserLogin(string username, string password)
        {
            return new User() { userid = username, name = "Udita", role = "Super Admin" };
        }
    }
}
