using API.Extensions;
using API.Middleware;

var builder = WebApplication.CreateBuilder(args);
// Add service to the container
builder.Services.AddApplicationService(builder.Configuration);
builder.Services.AddIdentityService(builder.Configuration);

var app = builder.Build();
// Configue the Http request pipeline
app.UseMiddleware<ExceptionMiddleware>();
app.UseCors(x=> x.AllowAnyHeader().AllowAnyMethod().
    WithOrigins("http://localhost:4200","https://localhost:4200"));
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
