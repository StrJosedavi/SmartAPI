using Microsoft.AspNetCore.Mvc;
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

    }

    private static Task HandleExceptionAsync(HttpContext context, HttpRequestException exception) 
    {

        ObjectResult JsonResult;

        switch (exception.StatusCode) 
        {
            case HttpStatusCode.NotFound:
                JsonResult = new ObjectResult(new { Success = false, Message = exception.Message }) { StatusCode = StatusCodes.Status404NotFound };
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                break;
            case HttpStatusCode.BadRequest:
                JsonResult = new ObjectResult(new { Success = false, Message = exception.Message }) { StatusCode = StatusCodes.Status400BadRequest };
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                break;
            default:
                JsonResult = new ObjectResult(new { Success = false, Message = exception.Message }) { StatusCode = StatusCodes.Status500InternalServerError };
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                break;
        }

        context.Response.ContentType = "application/json";

        var json = JsonSerializer.Serialize(JsonResult);
        return context.Response.WriteAsync(json);
    }
}
