using Microsoft.EntityFrameworkCore;
using Zoologico.API.Context;
using Zoologico.API.DTOs.Mapper;
using Zoologico.API.Models;
using Zoologico.API.Repository;
using Zoologico.API.Repository.Interfaces;
using Zoologico.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(MapperProfile));
builder.Services.AddDbContext<ZoologicoContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("connectionString")));
builder.Services.AddScoped<AnimalService>();
builder.Services.AddScoped<IRepository<AnimalModel>, AnimalRepository>();
builder.Services.AddScoped<CuidadoService>();
builder.Services.AddScoped<IRepository<CuidadoModel>, CuidadoRepository>();
builder.Services.AddSingleton<LogModel>();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("Angular", build =>
    {
        build.WithOrigins("http://localhost:4200")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    try
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<ZoologicoContext>();
        dbContext.Database.Migrate();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.ToString());
    }
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("Angular");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
