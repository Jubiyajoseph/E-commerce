using E_Commerce.Repository.Context;
using Microsoft.EntityFrameworkCore;
//using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<E_Commerce_DbContext>(option =>
{
    
    option.UseSqlServer(builder.Configuration["ConnectionString:SqlServer"], 
        options => options.MigrationsAssembly("E-Commerce.Repository"));
});
//builder.Services.AddScoped<UserAuthentication>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddCors(options => //for angular api
{
    options.AddPolicy("AllowAll",
      builder =>
      {
          builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
