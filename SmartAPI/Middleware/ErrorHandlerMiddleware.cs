using Microsoft.Data.SqlClient;
using SmartAPI.Middleware.ExceptionObjects;
using SmartAPI.Middleware.ResultException;
using SmartAPI.Services.Messages;
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
        catch (HandleExceptionGeneric ex) 
        {
            await HandleExceptionAsync(context, ex);
        }
        catch (SqlException ex) {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, HandleExceptionGeneric exception) 
    {
        //Utilizar o parametro exception depois, para registrar exceptions na base de dados

        HandleExceptionObjectResult jsonResult;

        switch (exception.StatusCode) 
        {
            case HttpStatusCode.NotFound:
                jsonResult = new HandleExceptionObjectResult() { Message = exception.Message };
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                break;
            case HttpStatusCode.BadRequest:
                jsonResult = new HandleExceptionObjectResult() { Message = exception.Message };
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                break;
            default:
                jsonResult = new HandleExceptionObjectResult() { Message = InternalMessage.Generic};
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                break;
        }

        context.Response.ContentType = "application/json";

        var json = JsonSerializer.Serialize(jsonResult);
        return context.Response.WriteAsync(json);
    }

    private static Task HandleExceptionAsync(HttpContext context, SqlException exception) 
    {
        //Utilizar o parametro exception depois, para registrar exceptions na base de dados

        HandleExceptionObjectResult JsonResult = new HandleExceptionObjectResult() { Message = InternalMessage.SQLError};
      
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Response.ContentType = "application/json";

        var json = JsonSerializer.Serialize(JsonResult);
        return context.Response.WriteAsync(json);
    }
}
