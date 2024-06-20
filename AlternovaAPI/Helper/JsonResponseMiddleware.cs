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
        // Almacenar el cuerpo original de la respuesta
        var originalBodyStream = context.Response.Body;

        try
        {
            using (var memoryStream = new MemoryStream())
            {
                // Redirigir la respuesta a un nuevo MemoryStream
                context.Response.Body = memoryStream;

                // Ejecutar el siguiente middleware / endpoint
                await _next(context);

                // Rebobinar el MemoryStream para leerlo
                memoryStream.Seek(0, SeekOrigin.Begin);

                // Leer el cuerpo de la respuesta en formato texto
                var responseBody = await new StreamReader(memoryStream).ReadToEndAsync();

                // Verificar si el tipo de contenido no está establecido o es texto plano
                if (!context.Response.HasStarted &&
                    (string.IsNullOrEmpty(context.Response.ContentType) ||
                    context.Response.ContentType == "text/plain" ||
                    context.Response.ContentType.StartsWith("text/")))
                {
                    // Convertir el cuerpo a JSON
                    var errorResponse = new ErrorResponse
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = responseBody
                    };

                    var jsonResponse = JsonConvert.SerializeObject(errorResponse);

                    // Establecer el tipo de contenido como JSON y reiniciar la longitud de la respuesta
                    context.Response.ContentType = "application/json";
                    context.Response.ContentLength = Encoding.UTF8.GetByteCount(jsonResponse);

                    // Escribir el JSON en el cuerpo de la respuesta original
                    context.Response.Body = originalBodyStream;
                    await context.Response.WriteAsync(jsonResponse);
                }
                else
                {
                    // Si ya está establecido correctamente, reenviar la respuesta original
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    await memoryStream.CopyToAsync(originalBodyStream);
                }
            }
        }
        catch (Exception ex)
        {
            // Manejar excepciones si es necesario
            Console.WriteLine($"Error en JsonResponseMiddleware: {ex.Message}");

            // Devolver una respuesta de error genérica en caso de excepción
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