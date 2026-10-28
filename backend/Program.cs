using Microsoft.EntityFrameworkCore;
using SmartMushroom_API.Data;

var builder = WebApplication.CreateBuilder(args);

// Ket noi co so du lieu MySQL
var connectionString = builder.Configuration
    .GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString)));

// Dang ky Controller va Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Hien thi Swagger khi chay o moi truong Development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => "Smart Mushroom API is running!");
app.MapControllers();

app.Run();