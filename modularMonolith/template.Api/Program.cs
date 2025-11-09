using Microsoft.OpenApi;
using Serilog;
using template.Api.Configuration.Middleware;
using template.Api.Configuration.ModulesRegistration;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
    builder.Services.AddProblemDetails();
    builder.Services.AddTelemetry();
    builder.Services.AddControllers();
    builder.Services.AddOpenApi();
    builder.Services.AddSwaggerUI();
    builder.Services.AddJWTAuthentication();
    builder.Host.ConfigureSerilog();
    builder.Services.AddSerilog();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
        app.UseSwagger(c => c.OpenApiVersion = OpenApiSpecVersion.OpenApi3_0);
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tu API v1");
            
           
        });
        app.MapGet("/test", (bool error = false) =>
        {
            if (!error) return Results.Ok("testing");
            else throw new Exception("I'm a test");
        });
    }

    app.UseHttpsRedirection();

    app.UseExceptionHandler();//global exception Handler

    app.UseAuthorization();

    app.MapControllers();

    app.UseMiddleware<CorrelationIdMiddleware>();

    app.Run();


}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    await Log.CloseAndFlushAsync();
}