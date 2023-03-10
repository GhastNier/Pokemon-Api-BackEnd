using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace BackEnd.Config;

public class OperationFilter
{
    public class OperationNameFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var nameAttribute = context.ApiDescription.ActionDescriptor.EndpointMetadata
                .OfType<HttpGetAttribute>()
                .FirstOrDefault()?.Name;

            if (!string.IsNullOrEmpty(nameAttribute))
            {
                operation.Tags = new[] { new OpenApiTag { Name = nameAttribute } };
            }
        }
    }
   
}