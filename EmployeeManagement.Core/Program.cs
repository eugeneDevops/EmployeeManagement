using EmployeeManagement.Application.Extensions;
using EmployeeManagement.Persistence.Extensions;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "EmployeeManagement", Version = "v1" });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLogging(config =>
{
    config.AddDebug();
    config.AddConsole();
});
builder.Services.AddPersistenceService(builder.Configuration);
builder.Services.AddApplicationServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EmployeeManagement"));
}
app.UseRouting();
app.UseResponseCaching();
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

await app.RunAsync();