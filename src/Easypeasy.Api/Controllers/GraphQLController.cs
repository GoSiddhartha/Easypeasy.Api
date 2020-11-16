
using System.Threading.Tasks;
using Easypeasy.Api.Queries;
using GraphQL;
using GraphQL.Types;

using Microsoft.AspNetCore.Mvc;

namespace Easypeasy.Api.Controllers
{
    [Produces("application/json")]
    public class GraphQLController : Controller
    {
        private readonly EasypeasyQuery _query;
        private readonly ISchema _schema;
        private readonly IDocumentExecuter _executer;
        public GraphQLController(ISchema schema,
        IDocumentExecuter executer)
        {
            _schema = schema;
            _executer = executer;
        }

        [HttpPost]
        [Route("graphql")]
        public async Task<IActionResult> Post([FromBody] GraphQLQueryDTO query)
        {
            if (query == null) return BadRequest("No query defined");

            using var schema = new Schema
            {
                Query = _query
            };

            var result = await _executer.ExecuteAsync(_ =>
            {
                _.Schema = _schema;
                _.Query = query.Query;
                _.Inputs = query.Variables;

            });
            if (result.Errors?.Count > 0)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}
