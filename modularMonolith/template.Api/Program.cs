
using template.Api.Configuration.Middleware;
using template.Api.Configuration.ModulesRegistration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Services.AddTelemetry();
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerUI();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapGet("/test", (bool error = false) => {
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
 