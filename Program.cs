using InternalPortal.Api;
using InternalPortal.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PortalDbContext>(options =>
    options.UseSqlite("Data source=portal.db"));

// Add authorization services
builder.Services.AddAuthorization();
builder.Services.AddCors();
builder.Services.AddControllers();


var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();

app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});

// Enable authorization middleware
app.UseAuthorization();
app.MapControllers();


app.Run();
