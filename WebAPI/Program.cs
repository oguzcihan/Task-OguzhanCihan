using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Business.Mapping;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
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

    //options.UseSqlServer(builder.Configuration.GetConnectionString("TaskApp"));
    options.UseSqlServer(builder.Configuration.GetConnectionString("TaskApp"), o =>
    {
        //repository layer in ismini reflection ile aldık ileride değiştirme olasılığı düşünülerek.
        o.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });

});

//Autofac plugin
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
//autofac oluşturulan module tanımlaması
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
app.UseAuthorization();

app.MapControllers();

app.Run();