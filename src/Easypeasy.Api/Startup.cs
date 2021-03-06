using GraphQL.Server;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Easypeasy.Api.Infrastructure.Service.Interface;
using Easypeasy.Api.Infrastructure.Queries;
using Easypeasy.Api.Infrastructure.Service;
using Easypeasy.Api.Infrastructure.Schemas;
using Easypeasy.Api.Infrastructure.Types;
using Easypeasy.Api.Infrastructure.Mutations;

namespace Easypeasy.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<ILoginService, LoginService>();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<EasypeasyQuery>();
            services.AddSingleton<EasypeasyMutation>();
            services.AddSingleton<MessageType>();
            services.AddSingleton<UserType>();
            services.AddSingleton<ISchema, EasypeasySchema>();


            services.AddGraphQL(options =>
            {
                options.EnableMetrics = true;
            })
            .AddErrorInfoProvider(opt => opt.ExposeExceptionStackTrace = true)
            .AddSystemTextJson()
            .AddUserContextBuilder(httpContext => new GraphQLUserContext { User = httpContext.User });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // add http for Schema at default url /graphql
            app.UseGraphQL<ISchema>();

            // use graphql-playground at default url /ui/playground
            app.UseGraphQLPlayground();
        }
    }
}
