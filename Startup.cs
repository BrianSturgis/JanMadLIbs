// These import built-in .NET namespaces that are required for creating a web application. They can help us construct HTTP requests, configure our project, and ensure necessary built-in functionality is present in the correct areas.
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
// add a namespace and class declaration:
namespace MadLibs
{
  public class Startup
  {
// This constructor will create an iteration of the Startup class that contains specific settings and variables to run our project successfully. It's required for configuring a basic ASP.NET Core MVC project.
    public Startup(IHostingEnvironment env)
    {
      var builder = new ConfigurationBuilder()
          .SetBasePath(env.ContentRootPath)
          .AddEnvironmentVariables();
      Configuration = builder.Build();
    }

    public IConfigurationRoot Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc();
    }

    public void Configure(IApplicationBuilder app)
    {
      app.UseDeveloperExceptionPage();
      app.UseMvc(routes =>
      {
          routes.MapRoute(
              name: "default",
              template: "{controller=Home}/{action=Index}/{id?}");
      });
      app.Run(async (context) =>
      {
          await context.Response.WriteAsync("Hello World!");
      });

    }
  }
}
