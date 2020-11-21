using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Text.Json.Serialization;
using System.Text.Json;

WebHost.CreateDefaultBuilder()
    .ConfigureServices(ConfigureServices)
    .Configure(ConfigureMiddlewares)
    .Build()
    .Run();

static void ConfigureServices(IServiceCollection services)
{
    services.AddControllers();
}

static void ConfigureMiddlewares(IApplicationBuilder app)
{
    app.UseCors();

    app.UseRouting();
    app.UseEndpoints(endpoints => endpoints.MapGet("/", MainGet));
}

static Task MainGet(HttpContext context) => context.Response.WriteAsync(JsonSerializer.Serialize(new Person { Name = "B", Surname = "Laurentiu" }));

public class Person
{
    [JsonPropertyName("lastname")] public string Name { get; set; }
    [JsonPropertyName("firstname")] public string Surname { get; set; }
}
