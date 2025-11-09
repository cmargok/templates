using Serilog.Events;

namespace template.Api.Common.Models.Configuration.Settings.Logging
{
    public class ConsoleLoggerConfiguration
    {
        public bool IsEnable { get; set; }
        public LogEventLevel MinimumLevel { get; set; }
    }
}
