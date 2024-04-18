using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FileUploadWebAPI.Middlewares
{
  public class AddNameHeaderParameter: IOperationFilter
  {
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
      if (operation.Parameters == null)
        operation.Parameters = new List<OpenApiParameter>();

      operation.Parameters.Add(new OpenApiParameter
      {
        Name = "Name",
        In = ParameterLocation.Header,
        Description = "Name",
        Required = false,
        Schema = new OpenApiSchema
        {
          Type = "String"
        }
      });
    }
  }
}
