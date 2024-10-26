﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using Microsoft.Identity.Abstractions;
using Microsoft.Identity.Web.Resource;
using Microsoft.Extensions.Configuration;
using Microsoft.FeatureManagement;
using Spawn.Management.Infrastructure;
using Spawn.Management.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Spawn.Management.Infrastructure.Persistance;
using Spawn.Common.Logging.Extensions;

namespace Spawn.Management.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.UseSpawnLogger(builder.Configuration);
        // Add services to the container.
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.Configure<CosmosSettings>(builder.Configuration.GetSection(nameof(CosmosSettings)));

        builder.Services.AddDbContextFactory<WorkflowContext>(
                               (IServiceProvider sp, DbContextOptionsBuilder opts) =>
                               {
                                   var cosmosSettings = sp
                                       .GetRequiredService<IOptions<CosmosSettings>>()
                                       .Value;

                                   opts.UseCosmos(
                                       cosmosSettings.EndPoint,
                                       cosmosSettings.AccessKey,
                                       nameof(WorkflowContext));
                               });

        builder.Services.AddFeatureManagement(builder.Configuration.GetSection("MyFeatureFlags"));
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
                builder.AllowAnyOrigin();
            });
        });

        builder.Services.AddApplicationServices();
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseCors("AllowAll");
        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
