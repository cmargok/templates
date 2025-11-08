using template.Api.Configuration.Handlers.Contracts;

namespace template.Api.Configuration.Middleware
{
    public class CorrelationIdMiddleware
    {

        private readonly RequestDelegate _next;

        public CorrelationIdMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ICorrelationIdHandler correlationIdHandler)
        {
            var correlationId = GetCorrelationIdTrace(context, correlationIdHandler);
            context.Items[correlationIdHandler.GetHeaderName()] = correlationId;
            AddToResponse(context, correlationIdHandler.GetHeaderName(), correlationId);

            await _next(context);
        }

        private static string GetCorrelationIdTrace(HttpContext context, ICorrelationIdHandler correlationIdHandler)
        {
            string correlationId;

            if (!context.Request.Headers.TryGetValue(correlationIdHandler.GetHeaderName(), out var incomingCorrelationId))
            {
                correlationId = correlationIdHandler.Get();
                context.Request.Headers[correlationIdHandler.GetHeaderName()] = correlationId;
            }
            else
            {
                correlationId = incomingCorrelationId!;

                if (correlationId == "")
                {
                    correlationId = correlationIdHandler.Get();
                    context.Request.Headers[correlationIdHandler.GetHeaderName()] = correlationId;
                }
            }

            correlationIdHandler.Set(correlationId!);

            return correlationId;
        }

        private static void AddToResponse(HttpContext context, string HeaderName, string correlationId)
        {
            context.Response.OnStarting(() =>
            {
                context.Response.Headers.TryAdd(HeaderName, correlationId);
                return Task.CompletedTask;
            });
        }
    }


}
