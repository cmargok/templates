using Serilog;
using Serilog.Events;
using template.Api.Common.Models.Configuration.Settings.Logging;

namespace template.Api.Configuration.ModulesRegistration
{
    public static class LoggingConfig
    {
        public static IHostBuilder ConfigureSerilog(this IHostBuilder hostBuilder)
        {
            hostBuilder.UseSerilog((context, services, loggerConfiguration) =>
                ConfigureSerilogLoger(loggerConfiguration, context.Configuration));
            return hostBuilder;
        }

        private static LoggerConfiguration ConfigureSerilogLoger(LoggerConfiguration loggerConfiguration, IConfiguration configuration)
        {
            var consoleLoggerConfig = new ConsoleLoggerConfiguration();
            configuration.GetSection("Logging:Console").Bind(consoleLoggerConfig);

            if(consoleLoggerConfig.IsEnable)
                loggerConfiguration.WriteTo.Console(consoleLoggerConfig.MinimumLevel);

            return loggerConfiguration;
        }
    }


}
