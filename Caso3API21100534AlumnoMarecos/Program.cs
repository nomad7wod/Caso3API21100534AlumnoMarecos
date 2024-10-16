using Microsoft.EntityFrameworkCore;
using PARCIAL.DOMAIN.Data;

var builder = WebApplication.CreateBuilder(args);


//hcaer referencia a la cadena de coneccion
var connectionString = builder.Configuration.GetConnectionString("DevConnection");
// add dbcontext 
builder.Services.AddDbContext<EventManagementDbContext>(options => options.UseSqlServer(connectionString));//no olvidar este paso necesario


// Add services to the container.

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
