using Microsoft.EntityFrameworkCore;
using upcsi730pc2veterinarycampaign.API.Crm.Application.Internal.CommandServices;
using upcsi730pc2veterinarycampaign.API.Crm.Domain.Repositories;
using upcsi730pc2veterinarycampaign.API.Crm.Domain.Services;
using upcsi730pc2veterinarycampaign.API.Crm.Infrastructure.Persistence.EFC.Repositories;
using upcsi730pc2veterinarycampaign.API.Shared.Domain.Repositories;
using upcsi730pc2veterinarycampaign.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using upcsi730pc2veterinarycampaign.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using upcsi730pc2veterinarycampaign.API.Shared.Infrastructure.Persistence.EFC.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.EnableAnnotations());

// Add Database Connection String
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (connectionString is null)
    throw new Exception("Database connection is not set.");

if (builder.Environment.IsDevelopment())
    builder.Services.AddDbContext<AppDbContext>(options =>
    {
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    });
else if (builder.Environment.IsProduction())
    builder.Services.AddDbContext<AppDbContext>(options =>
    {
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableDetailedErrors();
    });

// Configure Dependency Injection
builder.Services.AddScoped<IUnitOfWOrk, UnitOfWork>();

// News Bounded Context Dependency Injection
builder.Services.AddScoped<IManagerRepository, ManagerRepository>();
builder.Services.AddScoped<IManagerCommandService, ManagerCommandService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

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