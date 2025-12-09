using FluentValidation;
using Employees.System.Services;
using FluentValidation.AspNetCore;
using Employees.System.Middleware;
using Employees.System.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.
    AddFluentValidationAutoValidation()
    .AddFluentValidationAutoValidation();

builder.Services.AddValidatorsFromAssemblyContaining<Program>();

builder.Services.AddControllers();

//swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register service
builder.Services.AddScoped<IDataService, DataService>();

var app = builder.Build();

app.UseMiddleware<GlobalExceptionMiddleware>();

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
