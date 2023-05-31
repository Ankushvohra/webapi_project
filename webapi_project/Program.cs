using Microsoft.EntityFrameworkCore;
using webapi_project.Data;
using webapi_project.DTOMapping;
using webapi_project.Repository;
using webapi_project.Repository.IRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string cs = builder.Configuration.GetConnectionString("Constr");
builder.Services.AddDbContext<Applicationdbcontext>(option => option.UseSqlServer(cs));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<InationalParkRepository, NationalParkRepository>();
builder.Services.AddAutoMapper(typeof(MappingProfiler));
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
