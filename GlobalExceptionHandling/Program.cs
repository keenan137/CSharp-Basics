using GlobalExceptionHandling.CustomExceptions;
using GlobalExceptionHandling.Extensions;

var builder = WebApplication.CreateBuilder(args);

// new way (.net 8 and above)
builder.Services.AddExceptionHandlers();

var app = builder.Build();

app.UseExceptionHandler();

// older way (before .net8)
//app.UseMiddleware<OlderVersionErrorHandlerMiddleware>();


app.MapGet("/yo", () =>
{
    throw new ProductNotFoundException(Guid.NewGuid());
});

app.Run();
