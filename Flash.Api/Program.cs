using Flash.Api.Data;
using Flash.Api.Services;
using Flash.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<FlashContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("FlashConnection"));
});
builder.Services.AddTransient<ILocationServices, LocationServices>();
builder.Services.AddTransient<ILotServices, LotServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
