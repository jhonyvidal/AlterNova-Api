using AlternovaBusiness.Models;
using Newtonsoft.Json;
using System.Text;

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
                // Temporarily replace the response body with a memory stream
                context.Response.Body = memoryStream;

                // Call the next middleware in the pipeline
                await _next(context);

                // Reset the memory stream position to the beginning
                memoryStream.Seek(0, SeekOrigin.Begin);

                // Read the response body from the memory stream
                var responseBody = await new StreamReader(memoryStream).ReadToEndAsync();

                // Check if the response has not started and is of a text-based content type
                if (!context.Response.HasStarted &&
                    (string.IsNullOrEmpty(context.Response.ContentType) ||
                    context.Response.ContentType == "text/plain" ||
                    context.Response.ContentType.StartsWith("text/")))
                {
                    // Create an error response object
                    var errorResponse = new ErrorResponse
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = responseBody
                    };

                    // Serialize the error response to JSON
                    var jsonResponse = JsonConvert.SerializeObject(errorResponse);

                    // Set the response content type and length
                    context.Response.ContentType = "application/json";
                    context.Response.ContentLength = Encoding.UTF8.GetByteCount(jsonResponse);

                    // Restore the original response body stream
                    context.Response.Body = originalBodyStream;

                    // Write the JSON response
                    await context.Response.WriteAsync(jsonResponse);
                }
                else
                {
                    // If the response is not text-based, copy the memory stream to the original stream
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    await memoryStream.CopyToAsync(originalBodyStream);
                }
            }
        }
        catch (Exception ex)
        {
            // Log the exception to the console
            Console.WriteLine($"Error in JsonResponseMiddleware: {ex.Message}");

            // Create an error response object for internal server errors
            var errorResponse = new ErrorResponse
            {
                StatusCode = StatusCodes.Status500InternalServerError,
                Message = "Internal Server Error"
            };

            // Serialize the error response to JSON
            var jsonResponse = JsonConvert.SerializeObject(errorResponse);

            // Set the response content type, status code, and length
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentLength = Encoding.UTF8.GetByteCount(jsonResponse);

            // Restore the original response body stream
            context.Response.Body = originalBodyStream;

            // Write the JSON error response
            await context.Response.WriteAsync(jsonResponse);
        }
    }
}
