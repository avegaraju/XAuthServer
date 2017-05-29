using System;
using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

namespace XAuthServer.Middleware
{
    internal class RequestBuilderMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestBuilderMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            var request = context.Request;

            var userId = request.HttpContext.User.GetUserId();
            
            await _next(context);
        }
    }

    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserId(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            return principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
    }
}
