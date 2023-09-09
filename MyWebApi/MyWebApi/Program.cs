using Microsoft.EntityFrameworkCore;
using MyWebApi.Data;

using MyWebApi.Service;


var builder = WebApplication.CreateBuilder(args );
var configuration = new ConfigurationBuilder()
    .SetBasePath(System.IO.Directory.GetCurrentDirectory()) 
    .AddJsonFile("appsettings.json")
    .Build();
var connectionString = configuration.GetConnectionString("MyDB");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MyDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});
builder.Services.AddScoped<ILoaiRepository, LoaiRepository>();
builder.Services.AddScoped<IHangHoaReponsitory,HangHoaReponsitory>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
