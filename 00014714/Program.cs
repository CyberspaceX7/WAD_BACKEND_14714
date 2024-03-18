using _00014714.Data;
using _00014714.Models;
using _00014714.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuring SurveyFormDbContext to use SQL Server with the connection string from appsettings.
builder.Services.AddDbContext<SurveyFormDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("SqlServerConnection")));

// Registering SurveyRepository and CategoryRepository as scoped services for dependency injection.
builder.Services.AddScoped<IRepository<Survey>, SurveyRepository>();
builder.Services.AddScoped<IRepository<Category>, CategoryRepository>();

var app = builder.Build();

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
