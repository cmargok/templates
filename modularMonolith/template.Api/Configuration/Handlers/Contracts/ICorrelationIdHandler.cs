using Microsoft.AspNetCore.Authentication.OAuth;

namespace template.Api.Configuration.Handlers.Contracts
{
    public interface ICorrelationIdHandler
    {
        public string Get();
        public void Set(string correlationId);
        public string GetHeaderName();
    }

}
