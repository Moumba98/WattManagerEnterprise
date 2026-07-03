using Microsoft.EntityFrameworkCore;
using WattManager.Infrastructure.Persistence;
using WattManager.Application.Interfaces; 
using WattManager.Application.Services;   
using WattManager.Application.Repositories; 
using WattManager.Infrastructure.Repositories; 

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers(); 

// Configuration de la chaîne MySQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
                        builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

//  On enregistre LESf briques dans le conteneur
// =========================================================================
builder.Services.AddScoped<IIngenieurRepository, IngenieurRepository>();
builder.Services.AddScoped<IIngenieurService, IngenieurService>();
// =========================================================================

var app = builder.Build(); // Le conteneur se verrouille ici

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers(); 

app.Run();