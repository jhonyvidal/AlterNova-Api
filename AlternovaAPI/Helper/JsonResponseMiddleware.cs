using AlternovaBusiness.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

public class JsonResponseMiddleware
{
    private readonly RequestDelegate _next;

    public JsonResponseMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var originalBodyStream = context.Response.Body;

        try
        {
            using (var memoryStream = new MemoryStream())
            {
                context.Response.Body = memoryStream;

                await _next(context);

                memoryStream.Seek(0, SeekOrigin.Begin);

                var responseBody = await new StreamReader(memoryStream).ReadToEndAsync();

                if (!context.Response.HasStarted &&
                    (string.IsNullOrEmpty(context.Response.ContentType) ||
                    context.Response.ContentType == "text/plain" ||
                    context.Response.ContentType.StartsWith("text/")))
                {
                    var errorResponse = new ErrorResponse
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = responseBody
                    };

                    var jsonResponse = JsonConvert.SerializeObject(errorResponse);

                    context.Response.ContentType = "application/json";
                    context.Response.ContentLength = Encoding.UTF8.GetByteCount(jsonResponse);

                    context.Response.Body = originalBodyStream;
                    await context.Response.WriteAsync(jsonResponse);
                }
                else
                {
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    await memoryStream.CopyToAsync(originalBodyStream);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error en JsonResponseMiddleware: {ex.Message}");

            var errorResponse = new ErrorResponse
            {
                StatusCode = StatusCodes.Status500InternalServerError,
                Message = "Internal Server Error"
            };

            var jsonResponse = JsonConvert.SerializeObject(errorResponse);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentLength = Encoding.UTF8.GetByteCount(jsonResponse);
            context.Response.Body = originalBodyStream;
            await context.Response.WriteAsync(jsonResponse);
        }
    }
}