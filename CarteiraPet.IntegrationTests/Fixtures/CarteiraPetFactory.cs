using CarteiraPet.WebApp;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;

namespace CarteiraPet.IntegrationTests.Fixtures
{
    public class CarteiraPetFactory : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Test");
            var config = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .AddJsonFile("appsettings.Test.json", optional: false)
                .Build();
        }
    }
}
