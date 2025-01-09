using bookApi.Application.Extensions;
using bookApi.Application.Mappings;
using bookApi.Extensions;
using bookApi.infrastructure.Contexts;
using bookApi.infrastructure.Extensions;
using bookApi.Middleware;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Swagger extension
builder.Services.AddCustomSwagger();
//Infrastructure
builder.Services.AddInfrastructureServices();
//aplication
builder.Services.AddHttpContextAccessor();
builder.Services.AddApplicationServices();
//Validator
builder.Services.AddCustomValidators();

//Configure Db Context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")
));
//automapper
builder.Services.AddAutoMapper(typeof(UserProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
