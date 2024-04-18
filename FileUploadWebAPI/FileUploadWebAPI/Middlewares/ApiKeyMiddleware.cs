using FileUploadWebAPI;
using Microsoft.Extensions.Options;

namespace FileUploadAPI.Middlewares
{
  public class ApiKeyMiddleware
  {
    private readonly RequestDelegate _next;
    private readonly string _apiKey;

    public ApiKeyMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
    {
      _next = next;
      _apiKey = appSettings.Value.ApiKey;
    }

    public async Task InvokeAsync(HttpContext context)
    {
      if (!context.Request.Headers.TryGetValue("ApiKey", out var apiKeyHeader) ||
          apiKeyHeader != _apiKey)
      {
        context.Response.StatusCode = 401; // Unauthorized
        await context.Response.WriteAsync("Invalid API key.");
        return;
      }

      await _next(context);
    }
  }
}
