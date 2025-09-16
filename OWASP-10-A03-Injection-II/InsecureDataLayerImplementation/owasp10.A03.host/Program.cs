using owasp10.A03.api;
using owasp10.A03.data.access;
using owasp10.A03.data.access.Migrations;
using owasp10.A03.interactors;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddEndpoints()
                .AddBusinessServices()
                .AddDataServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Run db migrations
await SqLiteMigrationManager.RunMigrationsAsync();

await app.RunAsync();
