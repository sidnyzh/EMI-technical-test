using EMI.Transversal.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Net;

namespace EMI.Middlewares.GlobalExceptionMiddleware
{
    /// <summary>
    /// Extend the handler to capture the Exceptions
    /// </summary>
    public static class ExceptionMiddlewareExtensions
    {
        /// <summary>
        /// Get MVC BadRequest error Messages
        /// </summary>
        /// <param name="context">Current Action Context</param>
        /// <returns>The Error Details</returns>
        public static ErrorDetails ConstructErrorMessages(this ActionContext context)
        {
            var errors = context.ModelState.Values.Where(v => v.Errors.Count >= 1)
                    .SelectMany(v => v.Errors)
                    .Select(v => v.ErrorMessage)
                    .ToList();

            return new ErrorDetails
            {
                ErrorType = ReasonPhrases.GetReasonPhrase((int)HttpStatusCode.BadRequest),
                Errors = errors
            };
        }

        /// <summary>
        /// Handler the Exception and create a valid HttpResponse
        /// </summary>
        /// <param name="context">Current Http Context</param>
        /// <param name="exception">Exception Catched</param>
        public static Task HandleExceptionAsync(this HttpContext context, Exception exception)
        {
            var httpStatusCode = GetStatusResponse(exception);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)httpStatusCode;

            var errors = new List<string>() { exception.Message };
            if (exception.InnerException is not null)
            {
                errors.Add(exception.InnerException.Message);
            }

            var errorDetails = new ErrorDetails()
            {
                ErrorType = ReasonPhrases.GetReasonPhrase(context.Response.StatusCode),
                Errors = errors,
            };

            return context.Response.WriteAsync(errorDetails.ToString());
        }

        /// <summary>
        /// Allow to enable the Exception Middleware as service
        /// </summary>
        /// <param name="builder">Builder object to configure the service</param>
        /// <returns>The object to use in the Startup</returns>
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }

        /// <summary>
        /// Get the satus Code Response byt the Exception Type
        /// </summary>
        /// <param name="exception">Exception to handler</param>
        /// <returns>The HttpStatus Code</returns>
        private static HttpStatusCode GetStatusResponse(Exception exception)
        {
            var nameOfException = exception.GetType().BaseType.Name;

            if (nameOfException.Equals("BusinessException"))
            {
                nameOfException = exception.GetType().Name;
            }

            return nameOfException switch
            {
                // Internal Server Error 500
                nameof(InternalServerErrorException) => HttpStatusCode.InternalServerError,

                // Bad Request 400
                nameof(BadRequestException) => HttpStatusCode.BadRequest,

                //Unauthorized 401
                nameof(UnauthorizedException) => HttpStatusCode.Unauthorized,

                //Forbidden 403
                nameof(ForbiddenException) => HttpStatusCode.Forbidden,

                // Not Found 404
                nameof(NotFoundException) => HttpStatusCode.NotFound,

                //Request Timeout 408
                nameof(RequestTimeOutException) => HttpStatusCode.RequestTimeout,

                //Service Unavailable 503
                nameof(ServiceUnavailableException) => HttpStatusCode.ServiceUnavailable,

                // Default
                _ => HttpStatusCode.InternalServerError
            };
        }
    }
}
