namespace OfferHub.Host;

using Microsoft.OpenApi.Models;

static internal class SwaggerStartup
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddSwaggerGen(
            c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Main Api", Version = "v1"});
                c.SwaggerDoc("admin", new OpenApiInfo {Title = "Admin API", Version = "admin"});
            }
        );
    }

    public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsProduction())
        {
            return;
        }

        app.UseDeveloperExceptionPage();
        app.UseSwagger();

        app.UseSwaggerUI(
            c =>
            {
                c.RoutePrefix = "docs";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Main API V1");
                c.SwaggerEndpoint("/swagger/admin/swagger.json", "Admin Api");
            }
        );
    }
}