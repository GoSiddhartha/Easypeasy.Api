﻿using Easypeasy.Api.Infrastructure.Domain;
using GraphQL.Types;

namespace Easypeasy.Api.Infrastructure.Types
{
    public class UserType : ObjectGraphType<User>
    {
        public UserType()
        {
            Name = "User";
            Field(_ => _.userid).Description("User's unique id [email]");
            Field(_ => _.name).Description("Full name of the user");
            Field(_ => _.role).Description("Role of the user");
            Field<MessageType>(resolve: x => x.Source.response, name: "response");
        }
    }
}
