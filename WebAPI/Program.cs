using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Business.Mapping;
using Core.Utilities.AppSettings;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.Jwt;
using DataAccess.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using WebAPI.Middlewares;
using WebAPI.Modules.Autofac;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(MapProfile));

// DB connection
builder.Services.AddDbContext<AppDbContext>(options =>
{

    var appSettings = builder.Configuration.GetSection("DatabaseOptions").Get<AppSettings>();

    if (!appSettings.UseInMemoryDatabase)
    {
        options.UseSqlServer(appSettings.SqlConnectionString, o =>
        {
            //repository layer in ismini reflection ile al�nd� ileride de�i�tirme olas�l��� d���n�lerek.
            o.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
        });
    }
    else
    {
        options.UseInMemoryDatabase("taskDb");
    }

});

var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = tokenOptions.Issuer,
        ValidAudience = tokenOptions.Audience,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecretKey)
    };
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "O�uzhan Cihan Task", Version = "v1" });
    // JWT Kimlik Do�rulamay� Swagger i�in yap�land�rma
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] {}
            }
        });

});


//Autofac plugin
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
//autofac olu�turulan module tan�mlamas�
builder.Host.ConfigureContainer<ContainerBuilder>(cbuilder => cbuilder.RegisterModule(new AutofacBusinessModule()));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCustomException();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();