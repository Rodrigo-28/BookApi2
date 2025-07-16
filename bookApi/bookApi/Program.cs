using bookApi.Application.Extensions;
using bookApi.Application.Mappings;
using bookApi.Extensions;
using bookApi.infrastructure.Contexts;
using bookApi.infrastructure.Data;
using bookApi.infrastructure.Extensions;
using bookApi.Middleware;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Swagger extension
builder.Services.AddInfrastructureServices();
builder.Services.AddCustomSwagger();
builder.Services.AddApplicationServices();
builder.Services.AddCustomValidators();
builder.Services.AddControllers();

//Infrastructure
//aplication
//builder.Services.AddHttpContextAccessor();
//Validator

//Configure Db Context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
           .ConfigureWarnings(w => w.Ignore(RelationalEventId.PendingModelChangesWarning))
);

//Add Authorization and Authentication
builder.Services.AddCustomAuth(builder.Configuration);
//automapper
builder.Services.AddAutoMapper(typeof(UserProfile));

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();
    await seeder.SeedAsync();
}

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();
app.UseAuthentication();


app.UseAuthorization();

app.MapControllers();

app.Run();
