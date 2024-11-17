using Library.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add Swagger services
builder.Services.AddEndpointsApiExplorer(); // Required for minimal API and Swagger
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<BookService>(); // Register your custom service

var app = builder.Build();

// Configure Swagger middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Map controllers
app.MapControllers();

app.Run();
//Bac u kry 