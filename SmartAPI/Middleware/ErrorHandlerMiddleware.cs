using Microsoft.AspNetCore.Mvc;
using Npgsql;
using SmartAPI.Application.Middleware.ResultException;
using System.Net;
using System.Text.Json;

public class ErrorHandlerMiddleware {

    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate next) {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context) {
        try {
            await _next(context);
        }
        catch (HttpRequestException ex) {
            await HandleExceptionAsync(context, ex);
        }
        catch {
            await HandleExceptionAsync(context);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, HttpRequestException? exception = null) {

        HandleObjectResult JsonResult;

        switch (exception?.StatusCode) {

            case HttpStatusCode.NotFound:
                JsonResult = new HandleObjectResult() { success = false, message = exception.Message, statusCode = StatusCodes.Status404NotFound };
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                break;

            case HttpStatusCode.BadRequest:
                JsonResult = new HandleObjectResult() { success = false, message = exception.Message, statusCode = StatusCodes.Status400BadRequest };
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                break;

            case HttpStatusCode.Unauthorized:
                JsonResult = new HandleObjectResult() { success = false, message = exception.Message, statusCode = StatusCodes.Status401Unauthorized };
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                break;

            default:
                JsonResult = new HandleObjectResult() { success = false, message = "Ocorreu um erro inesperado", statusCode = StatusCodes.Status500InternalServerError };
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                break;
        }

        context.Response.ContentType = "application/json";

        var json = JsonSerializer.Serialize(JsonResult);
        return context.Response.WriteAsync(json);
    }
}
