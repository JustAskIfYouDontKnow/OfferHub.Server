﻿namespace OfferHub.Host;

using Microsoft.OpenApi.Models;

internal static class SwaggerStartup
{
    private const string Prefix = "OfferHub.";
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddSwaggerGen(
            c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Main Api", Version = "v1"});
                c.CustomSchemaIds(GetSwaggerSchemaId);
            }
        );
    }
    
    private static string GetSwaggerSchemaId(Type type)
    {
        var fullName = type.FullName;

        if (fullName == null || fullName.StartsWith(Prefix) == false)
        {
            throw new Exception(
                $"Type for Swagger schema MUST be in namespace {Prefix.Substring(0, Prefix.Length - 2)}. Type {fullName}"
            );
        }

        return fullName.Substring(Prefix.Length).Replace('+', '.');
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
            }
        );
    }
}