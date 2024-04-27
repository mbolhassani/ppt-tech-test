using Api.Data;
using Api.Repositories;
using Api.Requests;
using Api.Services.ImageService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", b => b.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
});
builder.Services.AddEntityFrameworkSqlite().AddDbContext<SqliteDbContext>(opt => opt.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnectionString")));
builder.Services.AddScoped<IImageRepository, SqliteRepository>();
builder.Services.AddScoped<IJSONServerRequest, JSONServerRequest>();

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
