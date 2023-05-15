using Microsoft.EntityFrameworkCore;
using Railway_Reservation_System_CS.Data;
using Railway_Reservation_System_CS.Interface;
using Railway_Reservation_System_CS.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddScoped<ITrain, TrainRepository>();
builder.Services.AddDbContext<RailwayContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("RailwayCS")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ITrain, TrainRepository>();
builder.Services.AddScoped<IPassenger, PassengerRepository>();
builder.Services.AddScoped<IPayment, PaymentRepository>();

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
