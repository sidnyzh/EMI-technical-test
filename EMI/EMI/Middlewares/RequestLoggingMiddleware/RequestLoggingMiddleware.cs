using EMI.Authentication.JWT;
using EMI.Domain.Entity;
using EMI.Repository.EFC;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace EMI.Middlewares.RequestLoggingMiddleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;

        }

        public async Task InvokeAsync(HttpContext context, LogDbContext logDbContext, IJWTInformation jWTInformation)
        {
            var request = context.Request;

            request.EnableBuffering();

            string body = await ReadRequestBodyAsync(request);

            string email = jWTInformation.GetEmail();

            var log = new RequestLog
            {
                Timestamp = DateTime.UtcNow,
                RequestMethod = request.Method,
                RequestPath = request.Path,
                QueryString = request.QueryString.HasValue ? request.QueryString.Value : null,
                RequestBody = !string.IsNullOrWhiteSpace(body) ? body : null,
                Headers = JsonSerializer.Serialize(request.Headers.ToDictionary(h => h.Key, h => h.Value.ToString())),
                Email = email,
                Identifier = context.TraceIdentifier
            };

            logDbContext.RequestLogs.Add(log);
            await logDbContext.SaveChangesAsync();

            await _next(context);
        }

        private async Task<string> ReadRequestBodyAsync(HttpRequest request)
        {
            request.Body.Position = 0; 
            using var reader = new StreamReader(request.Body, Encoding.UTF8, leaveOpen: true);
            var body = await reader.ReadToEndAsync();
            request.Body.Position = 0; 
            return body;
        }
    }
}
