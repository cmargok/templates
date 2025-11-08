using Microsoft.AspNetCore.Authentication.OAuth;
using template.Api.Configuration.Handlers.Contracts;

namespace template.Api.Configuration.Handlers.Implementations
{
    public sealed class CorrelationIdHandler : ICorrelationIdHandler
    {
        public const string CorrelationIdHeader = "X-Correlation-Id";

        private string _correlationId = "";

        public string Get()
            => _correlationId is "" ? Guid.NewGuid().ToString() : _correlationId;
        public string GetHeaderName()
            => CorrelationIdHeader;
        public void Set(string correlationId)
            => _correlationId = correlationId;
    }
}
