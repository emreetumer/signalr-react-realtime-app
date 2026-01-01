using Microsoft.EntityFrameworkCore;
using SignalRLearning.API.Data;
using SignalRLearning.API.Hubs;

var builder = WebApplication.CreateBuilder(args);

// 1. DB Context
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. SignalR Servisini Ekle
builder.Services.AddSignalR();

// 3. CORS Politikasý (React portu genelde 5173 veya 3000 olur, ikisine de izin verelim)
// ÖNEMLÝ: SignalR için .AllowCredentials() ÞARTTIR!
builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactAppPolicy", builder =>
    {
        builder.WithOrigins("http://localhost:5173", "http://localhost:3000")
               .AllowAnyHeader()
               .AllowAnyMethod()
               .AllowCredentials(); // SignalR için zorunlu
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("ReactAppPolicy");

app.UseAuthorization();
app.MapControllers();

// 4. Hub Endpoint'ini Belirle (React bu adrese baðlanacak)
app.MapHub<ProductHub>("/productHub");

app.Run();