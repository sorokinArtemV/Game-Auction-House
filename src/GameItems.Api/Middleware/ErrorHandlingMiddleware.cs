﻿using GameItems.Core.Exceptions;

namespace ItemsService.Middleware;

public class ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (NotFoundException ex)
        {
            logger.LogWarning(ex, ex.Message);
            context.Response.StatusCode = 404;

            await context.Response.WriteAsync(ex.Message);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            context.Response.StatusCode = 500;

            await context.Response.WriteAsync("Something went wrong while processing your request.");
        }
    }
}