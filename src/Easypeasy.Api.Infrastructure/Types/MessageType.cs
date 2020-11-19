using Easypeasy.Api.Infrastructure.Domain;
using GraphQL.Types;

namespace Easypeasy.Api.Infrastructure.Types
{
    public class MessageType : ObjectGraphType<Message>
    {
        public MessageType()
        {
            Name = "Message";
            Field(_ => _.message).Description("Response message if any");
            Field(_ => _.status).Description("Request response status");
        }
    }
}
