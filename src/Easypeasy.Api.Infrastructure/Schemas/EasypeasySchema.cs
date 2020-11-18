using Easypeasy.Api.Infrastructure.Queries;
using GraphQL.Types;
using GraphQL.Utilities;
using System;

namespace Easypeasy.Api.Infrastructure.Schemas
{
    public class EasypeasySchema : Schema
    {
        public EasypeasySchema(IServiceProvider provider)
            : base(provider)
        {
            Query = provider.GetRequiredService<EasypeasyQuery>();
        }
    }
}
