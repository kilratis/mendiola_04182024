﻿using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

public class AddApiKeyHeaderParameter : IOperationFilter
{
  public void Apply(OpenApiOperation operation, OperationFilterContext context)
  {
    if (operation.Parameters == null)
      operation.Parameters = new List<OpenApiParameter>();

    operation.Parameters.Add(new OpenApiParameter
    {
      Name = "ApiKey",
      In = ParameterLocation.Header,
      Description = "API Key",
      Required = false,
      Schema = new OpenApiSchema
      {
        Type = "String"
      }
    });
  }
}
