using Microsoft.Extensions.Logging;
using CarRegistrationApi.Data;
using CarRegistrationApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Car Registration API", Version = "v1" });
});

// Add CORS services
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());
});

// Add custom services
builder.Services.AddSingleton<EmailService>();
builder.Services.AddHostedService<NotificationService>();
builder.Services.AddControllers();

// Configure EF Core
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add configuration for email settings
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Configure Kestrel to use the correct ports
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5091); // HTTP port
    options.ListenAnyIP(7254, listenOptions =>
    {
        listenOptions.UseHttps(); // HTTPS port
    });
});

// Configure logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Build the app
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Car Registration API V1");
        c.RoutePrefix = string.Empty; // Set Swagger UI at the root
    });
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Car Registration API V1");
        c.RoutePrefix = "swagger"; // Adjust as needed for production
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors("AllowAll"); // Apply CORS policy

app.MapControllers(); // Enable attribute routing

// Ensure the database is created
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.EnsureCreated();
}

app.Run();
