
using Autofac;
using Autofac.Extensions.DependencyInjection;
using CoreWebApi;
using CoreWebApi.Models;
using CoreWebApi.Services;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(AutomapperProfile));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddTransient<IMethods,Methods>();
var app = builder.Build();

// Autofac Registrations
//builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

// Call ConfigureContainer on the Host sub property 
//builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
//{
//    builder.RegisterModule(new AutofacModule());
//});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.Run();
