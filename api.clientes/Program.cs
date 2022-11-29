using api.clientes.Data;
using api.clientes.Models;
using api.clientes.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Api Clientes",
        Description = "Api de clientes",
        TermsOfService = new Uri("https://example.com/terms")
    });
});

var connectionString = builder.Configuration.GetConnectionString("PostgreSQLConnection");

builder.Services.AddDbContext<Programacion8vo>(options =>
    options.UseNpgsql(connectionString));

var app = builder.Build();

Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
                .CreateLogger();

// Configure the HTTP request pipeline.    
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options =>
    {

        options.SerializeAsV2 = true;
    });

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.MapPost("/clientes/", async (Clientes clientes, Programacion8vo db) =>
{
    try
    {
        ClientesServices clienteServices = new ClientesServices();

        Log.Information("Inicializa consulta de clientes");
        string datos = await clienteServices.addClientes(clientes, db);

        return Results.Created($"/clientes/{clientes.Id}", clientes);
    }
    catch (global::System.Exception ex)
    {
        Log.Error($"Error: {ex.StackTrace}");
        throw;
    }
});

app.MapGet("/clientes/{id:int}", async (int id, Programacion8vo db) =>
{
    return await db.Clientes.FindAsync(id)
              is Clientes cliente ? Results.Ok(cliente) : Results.NotFound();
});

app.MapGet("/ListClientes/", async (Programacion8vo db) =>
{
    return await db.Clientes.FindAsync()
              is Clientes cliente ? Results.Ok(cliente) : Results.NotFound();
});


app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}