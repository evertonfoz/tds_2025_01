using System;
using System.Net;
using System.Text.Json;

namespace MonolitoDemo.Api.Middlewares;

public class ExceptionMiddleWare(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task Invoke(HttpContext context) {
        try {
            await _next(context);
        } catch(Exception exception) {
            await HandleExceptionAsync(context, exception);
        }
    }

    public  static Task HandleExceptionAsync(HttpContext context, Exception exception) {
        context.Response.ContentType = "application/json";
        var options = new JsonSerializerOptions 
        {
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };
        string jsonResponse;

        if (exception is Exceptions.ValidationException validationException) {
            context.Response.StatusCode = (int) HttpStatusCode.BadRequest;
             jsonResponse = JsonSerializer.Serialize(new {errors = validationException.Errors}, options);
            return context.Response.WriteAsync(jsonResponse);
        }

        var response = new {message = exception.Message};
        jsonResponse = JsonSerializer.Serialize(response, options);
        context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;

        return context.Response.WriteAsync(jsonResponse);
    }
}
