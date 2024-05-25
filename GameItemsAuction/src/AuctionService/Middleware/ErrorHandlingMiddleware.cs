using AuctionService.Exceptions;

namespace AuctionService.Middleware;

public class ErrorHandlingMiddleware() : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (NotFoundException ex)
        {
            context.Response.StatusCode = 404;

            await context.Response.WriteAsync(ex.Message);
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = 500;

            await context.Response.WriteAsync("Something went wrong while processing your request.");
        }
    }
}