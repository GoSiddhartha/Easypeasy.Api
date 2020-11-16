using Easypeasy.Api.Domain;
using Easypeasy.Api.Infrastructure.Interface;
using Easypeasy.Api.Types;
using GraphQL;
using GraphQL.Types;

namespace Easypeasy.Api.Queries
{
    public partial class EasypeasyQuery : ObjectGraphType
    {
        public static ILogin _login { get; private set; }
        public EasypeasyQuery(ILogin login)
        {
            _login = login;

            var loginArguements = new QueryArguments(
                 new QueryArgument<StringGraphType> { Name = "userid" },
                 new QueryArgument<StringGraphType> { Name = "password" }
             );
            Field<UserType>(
                name: "userlogin",
                arguments: loginArguements,
                resolve: context =>
                {
                    var qa = new Login { password = context.GetArgument<string>("password"), userid = context.GetArgument<string>("userid") };
                    return _login.UserLogin(qa.userid, qa.password);
                });
        }
    }
}
