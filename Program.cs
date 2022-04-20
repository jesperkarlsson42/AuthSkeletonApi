using AspNetAuthApi.Data;
using Microsoft.EntityFrameworkCore;

DotNetEnv.Env.Load();
var ConnectionString = System.Environment.GetEnvironmentVariable("Connection_string");

if(string.IsNullOrEmpty(ConnectionString))
{
    throw new Exception("Connecting to the database failed");
}
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(
    options => options.UseSqlServer(ConnectionString)
);
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
