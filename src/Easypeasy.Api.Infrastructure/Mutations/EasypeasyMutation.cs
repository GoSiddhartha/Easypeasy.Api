using Easypeasy.Api.Infrastructure.Domain;
using Easypeasy.Api.Infrastructure.Service.Interface;
using Easypeasy.Api.Infrastructure.Types;
using GraphQL;
using GraphQL.Types;

namespace Easypeasy.Api.Infrastructure.Mutations
{
    public class EasypeasyMutation : ObjectGraphType<object>
    {
        public static IUserService _user { get; private set; }
        public EasypeasyMutation(IUserService user)
        {
            _user = user;
            Name = "Mutation";

            var userArguements = new QueryArguments(
                 new QueryArgument<StringGraphType> { Name = "emailid" },
                 new QueryArgument<StringGraphType> { Name = "fullname" },
                 new QueryArgument<StringGraphType> { Name = "rolename" }
             );

            Field<MessageType>(
                "createuser",
                arguments: userArguements,
                resolve: context =>
                {
                    var userparam = new User
                    {
                        name = context.GetArgument<string>("userid"),
                        userid = context.GetArgument<string>("userid"),
                        role = context.GetArgument<string>("userid")
                    };
                    return _user.CreateUser(userparam);
                });
        }
    }
}
