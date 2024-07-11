using Microsoft.AspNetCore.Diagnostics;

namespace GST_API.Middlewares
{
    public class ExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(
            HttpContext context,
            Exception exception,
            CancellationToken cancellation)
        {
            // Your response object
            var error = new { message = exception.Message, stackTrace = exception.StackTrace };
            await context.Response.WriteAsJsonAsync(error, cancellation);
            return true;
        }
    }
}
