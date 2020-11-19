using Easypeasy.Api.Infrastructure.Domain;

namespace Easypeasy.Api.Infrastructure.Service.Interface
{
    public interface IUserService
    {
        Message CreateUser(User user);
    }
}
