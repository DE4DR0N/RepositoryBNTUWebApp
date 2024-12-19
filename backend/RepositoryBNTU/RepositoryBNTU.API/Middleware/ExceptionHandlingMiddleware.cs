﻿using System.Net;
using RepositoryBNTU.API.DTOs;

namespace RepositoryBNTU.API.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        _logger.LogError(exception, "An unexpected error occurred.");

        ExceptionResponse response;
        if (exception.Message.Contains("Conflict"))
        {
            response = new ExceptionResponse(HttpStatusCode.Conflict, $"Conflict situation occured: {exception.Message}");
        }
        else
        {
            response = exception switch
            {
                ApplicationException _ => new ExceptionResponse(HttpStatusCode.BadRequest, $"Application exception occurred: {exception.Message}"),
                KeyNotFoundException _ => new ExceptionResponse(HttpStatusCode.NotFound, $"The request key not found: {exception.Message}"),
                UnauthorizedAccessException _ => new ExceptionResponse(HttpStatusCode.Unauthorized, "Unauthorized."),
                AccessViolationException _ => new ExceptionResponse(HttpStatusCode.Forbidden, "Forbidden."),
                _ => new ExceptionResponse(HttpStatusCode.InternalServerError, $"Internal server error: {exception.Message}")
            };
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)response.StatusCode;
        await context.Response.WriteAsJsonAsync(response);
    }
}