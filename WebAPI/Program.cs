using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Business.DependencyResolvers.Autofac;
using Business.Mapping;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebAPI.Middlewares;

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

    //options.UseSqlServer(builder.Configuration.GetConnectionString("TaskApp"));
    options.UseSqlServer(builder.Configuration.GetConnectionString("TaskApp"), o =>
    {
        //repository layer in ismini reflection ile aldýk ileride deðiþtirme olasýlýðý düþünülerek.
        o.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });

});

//Autofac plugin
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(build =>
    {
        build.RegisterModule(new AutofacBusinessModule());
    });


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCustomException();
app.UseAuthorization();

app.MapControllers();

app.Run();