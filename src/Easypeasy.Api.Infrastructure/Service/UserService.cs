using Easypeasy.Api.Infrastructure.Domain;
using Easypeasy.Api.Infrastructure.Service.Interface;

namespace Easypeasy.Api.Infrastructure.Service
{
    public class UserService : IUserService
    {
        public Message CreateUser(User user)
        {
            return new Message { status = true, message = "User was successfully created" };
        }
    }
}
