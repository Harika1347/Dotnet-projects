using Microsoft.EntityFrameworkCore;
using PaymentAPI.Models;

var builder = WebApplication.CreateBuilder(args);
var  CORSOpenPolicy = "OpenCORSPolicy";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{

    options.AddPolicy(
   name: CORSOpenPolicy,
   builder => {
       builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
   });
});

builder.Services.AddDbContext<PaymentDetailContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(CORSOpenPolicy);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
