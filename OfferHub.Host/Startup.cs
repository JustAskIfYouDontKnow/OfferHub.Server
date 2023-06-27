namespace OfferHub.Host;
public class Startup
{
    public IConfiguration Configuration { get; }

    public IWebHostEnvironment Environment { get; }


    public Startup(IConfiguration configuration, IWebHostEnvironment environment)
    {
        Configuration = configuration;
        Environment = environment;
    }


    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors(
            options =>
            {
                options.AddPolicy(
                    "AllowOrigin",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200", "https://localhost:4200")
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials();
                    }
                );
            }
        );

        SwaggerStartup.ConfigureServices(services);
        RegisterDatabaseServices(services);

    }


    private void RegisterDatabaseServices(IServiceCollection services) { }


    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        SwaggerStartup.Configure(app, env);
        
        app.UseCors("AllowOrigin");
        app.UseRouting();

        app.UseEndpoints(
            endpoints =>
            {
                endpoints.MapControllers();
            });
    }
}