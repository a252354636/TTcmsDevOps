using FunctionalTests.Middleware;
using Microsoft.AspNetCore.Builder;
using TTcms.Services.Ordering.API;
using Microsoft.Extensions.Configuration;

namespace FunctionalTests.Services.Ordering
{
    public class OrderingTestsStartup : Startup
    {
        public OrderingTestsStartup(IConfiguration env) : base(env)
        {
        }

        protected override void ConfigureAuth(IApplicationBuilder app)
        {
            if (Configuration["isTest"] == bool.TrueString.ToLowerInvariant())
            {
                app.UseMiddleware<AutoAuthorizeMiddleware>();
                app.UseAuthorization();
            }
            else
            {
                base.ConfigureAuth(app);
            }
        }
    }
}
