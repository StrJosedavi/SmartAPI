using SmartAPI.Application.Middleware.ResultException;
using System;
using System.Net;
using System.Text.Json;

public class ErrorHandlerMiddleware {

    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate next) 
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try 
        {
            await _next(context);
        }
        catch (HttpRequestException ex) 
        {
            await HandleExceptionAsync(context, ex);
        }
        catch 
        {
            await HandleExceptionAsync(context);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, HttpRequestException exception) 
    {

        HandleObjectResult JsonResult;

        switch (exception.StatusCode) 
        {
            case HttpStatusCode.NotFound:
                JsonResult = new HandleObjectResult() { message = exception.Message };
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                break;
            case HttpStatusCode.BadRequest:
                JsonResult = new HandleObjectResult() { message = exception.Message };
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                break;
            default:
                JsonResult = new HandleObjectResult() { message = exception.Message };
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                break;
        }

        context.Response.ContentType = "application/json";

        var json = JsonSerializer.Serialize(JsonResult);
        return context.Response.WriteAsync(json);
    }

    private static Task HandleExceptionAsync(HttpContext context)
    {
        HandleObjectResult JsonResult = new HandleObjectResult() { message = "Um erro interno ocorreu em nosso servidor e estamos trabalhando para corrigi-lo." };
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;

        context.Response.ContentType = "application/json";

        var json = JsonSerializer.Serialize(JsonResult);
        return context.Response.WriteAsync(json);
    }
}
