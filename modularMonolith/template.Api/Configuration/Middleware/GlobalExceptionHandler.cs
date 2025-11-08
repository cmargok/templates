using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using template.Api.Configuration.Handlers.Implementations;

namespace template.Api.Configuration.Middleware
{
    public sealed class GlobalExceptionHandler : IExceptionHandler
    {
        private const string ERROR_MESSAGE = "A problem has occurred while your request is being processed.";

        private readonly IHostEnvironment env;
        private readonly ILogger<GlobalExceptionHandler> _logger;
        public GlobalExceptionHandler(IHostEnvironment env, ILogger<GlobalExceptionHandler> logger)
        {
            this.env = env;
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var problemDetails = CreateProblemDetails(httpContext, exception);

            await httpContext.Response.WriteAsJsonAsync(
                problemDetails,
                options: null,
                contentType: "application/problem+json",
                cancellationToken: cancellationToken);

            return true;
        }

        private ProblemDetails CreateProblemDetails(in HttpContext context, in Exception exception)
        {
            var problemDetails = new ProblemDetails
            {
                Status = (int)HttpStatusCode.InternalServerError,
                Type = exception.GetType().Name,
                Title = ERROR_MESSAGE,
            };

            var correlationIdObject = context.Items[CorrelationIdHandler.CorrelationIdHeader];

            string correlationId = correlationIdObject != null ? correlationIdObject?.ToString()! : Guid.NewGuid().ToString();

            _logger.LogError("\nAn Exception has occurred \n\tCorrelation-id : {correlationId}\n\t\tMessage: {message}\n", correlationId, exception.Message);


            if (env.IsDevelopment())
            {
                problemDetails.Detail = exception.Message;
                problemDetails.Extensions[CorrelationIdHandler.CorrelationIdHeader] = correlationId;
                problemDetails.Extensions["Date"] = $"{DateTime.Now:dd:mm:yyyy:hh:mm:ss}";
                problemDetails.Instance = context.Request.Path;
            }

            return problemDetails;
        }
    }
}
