using Microsoft.EntityFrameworkCore;
using STBEmployeeEntry.Data;
using STBEmployeeEntry.Interface;
using STBEmployeeEntry.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var connection = builder.Configuration.GetConnectionString("TestDb");
builder.Services.AddDbContext<STBEmployeeEntryDbContext>(options => options.UseSqlServer(connection));
builder.Services.AddScoped<ISTBEmployeeEntry, STBEmployeeService>();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
