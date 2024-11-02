using System.Net;

namespace TeamService.ExceptionHandling
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next) 
        { 
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (NotFoundException ex) 
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(ex.Message);
            }
        }
    }
}
