using CQRS.API.DependencyInjection;
using CQRS.Application.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAppDbContext();
builder.Services.AddAppMediatR();
builder.Services.AddAppServices();
builder.Services.AddAppCors();

builder.Services.AddOpenApi();

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowAll");

app.MapControllers();

app.Run();