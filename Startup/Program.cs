using NLog.Web;
using SchoolWeb.API.Startup;

var builder = WebApplication.CreateBuilder(args);
builder.Services.RegisterApplicationServices(builder);

var app = builder.Build();
app.ConfigureMiddleware();
app.Run();
