using FileUploadAPI.Middlewares;
using FileUploadWebAPI;
using FileUploadWebAPI.Middlewares;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<AppSettings>(configuration.GetSection("AppSettings"));

builder.Services.AddSwaggerGen(c =>
{
  c.SwaggerDoc("v1", new OpenApiInfo { Title = "API Key", Version = "v1" });
  c.OperationFilter<AddApiKeyHeaderParameter>();
});

builder.Services.AddSwaggerGen(c =>
{
  c.SwaggerDoc("v2", new OpenApiInfo { Title = "Name", Version = "v1" });
  c.OperationFilter<AddNameHeaderParameter>();
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ApiKeyMiddleware>();

app.MapControllers();

app.Run();
