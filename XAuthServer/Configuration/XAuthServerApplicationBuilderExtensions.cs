using Microsoft.AspNetCore.Builder;

using XAuthServer.Middleware;

namespace XAuthServer.Configuration
{
    public static class XAuthServerApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseXAuthServer(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseMiddleware<RequestBuilderMiddleware>();

            return applicationBuilder;
        }
    }
}
