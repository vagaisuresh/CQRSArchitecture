using CQRS.API.DIs;
using CQRS.Application.DIs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureSqlContext();
builder.Services.ConfigureMediatR();
builder.Services.ConfigureDependencyBindings();

builder.Services.AddOpenApi();

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();