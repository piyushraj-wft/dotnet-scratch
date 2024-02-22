using System.Data;
using System.Reflection;
using DbUp;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

//sql connection
builder.Services.AddScoped<IDbConnection>(db => new SqlConnection(configuration.GetConnectionString("MsSqlConnection")));

// db up configuration
var migrator = DeployChanges.To.SqlDatabase(configuration.GetConnectionString("MsSqlConnection"))
.WithScriptsFromFileSystem("../dotnet-scratch/Migration")
.LogToConsole().Build();

// Perform the upgrade
var result = migrator.PerformUpgrade();
if (!result.Successful)
{
    Console.WriteLine(result.Error);
}

// Medaitr

builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));


// Add services to the container.
builder.Services.AddScoped<IOrganizationRepository, OrganizationRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(ui =>
    {
        ui.SwaggerEndpoint("/swagger/v1/swagger.json", "MCQ API");
    });
}
app.MapControllers();
app.UseHttpsRedirection();








app.Run();





//basicallt its like instantiated when defined

//data return garna useful hunxa