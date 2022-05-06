using Microsoft.EntityFrameworkCore;
using Pagos.Data;
using Pagos.PagosMapper;
using Pagos.Repository;
using Pagos.Repository.IRepository;

var builder = WebApplication.CreateBuilder(args);

//Conexion a Postgres jua jua
builder.Services.AddDbContext<AplicationDbContext>(opciones => opciones.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConection")));
builder.Services.AddScoped<IfPagoContribAseIdepRepository, fPagoContribAseIdepRepository>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(PagosMapper));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(options => {
    options.WithOrigins("https://localhost:44478");
    options.AllowAnyMethod();
    options.AllowAnyHeader();
});
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
