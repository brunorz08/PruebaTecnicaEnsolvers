using EnsolversPT.Context;
using EnsolversPT.Interfaces;
using EnsolversPT.Managers;
using EnsolversPT.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.a



builder.Services.AddControllers();
string connectionString = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<NotesContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddTransient<IService<Note>,NotesManager>();

builder.Services.AddCors(options => options.AddPolicy("BRUNO", builder =>
{
    builder.AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin();
}));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseRouting();

app.UseCors("BRUNO");

app.UseAuthorization();

app.MapControllers();

app.Run();
