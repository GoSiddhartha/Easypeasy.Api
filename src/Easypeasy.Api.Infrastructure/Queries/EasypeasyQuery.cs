using Easypeasy.Api.Infrastructure.Service.Interface;
using Easypeasy.Api.Infrastructure.Types;
using GraphQL;
using GraphQL.Types;

namespace Easypeasy.Api.Infrastructure.Queries
{
    public class EasypeasyQuery : ObjectGraphType<object>
    {
        public static ILoginService _login { get; private set; }
        public EasypeasyQuery(ILoginService login)
        {
            _login = login;
            Name = "Query";
            
            var loginArguements = new QueryArguments(
                 new QueryArgument<StringGraphType> { Name = "userid" },
                 new QueryArgument<StringGraphType> { Name = "password" }
             );

            Field<UserType>(
                "login",
                arguments: loginArguements,
                resolve: context => _login.UserLogin(context.GetArgument<string>("userid"), context.GetArgument<string>("password") )
            );
        }
    }
}
