using Microsoft.EntityFrameworkCore;
using SchoolWeb.API.Startup;

var builder = WebApplication.CreateBuilder(args);
string connectionString = builder.Configuration.GetConnectionString("SchoolDbContext");
builder.Services.RegisterApplicationServices(connectionString);

var app = builder.Build();
app.ConfigureMiddleware();
app.Run();
