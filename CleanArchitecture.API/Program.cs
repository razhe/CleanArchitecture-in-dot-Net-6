using AutoMapper;
using CleanArchitecture.API.Extensions;
using CleanArchitecture.API.Mappers;
using CleanArchitecture.Application.Abstractions;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Infrastructure.Database;
using CleanArchitecture.Infrastructure.Database.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext
builder.Services.AddDbContext<ChinookContext>( options => options
    .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Dependency Injection
builder.Services.AddAplicationServices();

// AutoMapper
builder.Services.AddMappers();

//CorsPolicy (Extended)
builder.Services.ConfigureCors();

//Ignore circular references
builder.Services.IngoreJsonCircularReferences();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Adding CorsPolicy to http canalization request
app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
