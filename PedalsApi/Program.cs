using Microsoft.EntityFrameworkCore;
using PedalsApi.Extensions;
using PedalsApi.Infrastructure.EntityFramework.DbContexts;

var builder = WebApplication.CreateBuilder(args);
var allowSpecificOrigins = "pedals-ui";
// Add services to the container.
builder.Services.AddHealthChecks();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowSpecificOrigins, policy =>
    {
        policy.WithOrigins("http://localhost:5251");
    });
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddServices(builder.Configuration);
builder.Configuration.AddEnvironmentVariables(prefix: "Pedals_");
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(allowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHealthChecks("/health");

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<PedalsContext>();
    await dbContext.Database.MigrateAsync();
}
app.Run();
