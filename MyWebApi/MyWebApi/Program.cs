using Microsoft.EntityFrameworkCore;
using MyWebApi.Data;
<<<<<<< HEAD
using MyWebApi.Service;
=======
>>>>>>> 505a09b04007c96d6719b83993edc1136cc8b4e9

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
<<<<<<< HEAD
builder.Services.AddScoped<ILoaiRepository, LoaiRepository>();
builder.Services.AddScoped<IHangHoaReponsitory,HangHoaReponsitory>();
=======
>>>>>>> 505a09b04007c96d6719b83993edc1136cc8b4e9

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
