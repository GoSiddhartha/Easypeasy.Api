
using Easypeasy.Api.Domain;
using Easypeasy.Api.Infrastructure.Interface;

namespace Easypeasy.Api.Infrastructure
{
    public class Login : ILogin
    {
        public User UserLogin(string username, string password)
        {
            return new Domain.User();
        }
    }
}
