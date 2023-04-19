using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EstudiantesBack.Data;




var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<EstudiantesBackContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("EstudiantesBackContext") ?? throw new InvalidOperationException("Connection string 'EstudiantesBackContext' not found.")));

//cors
var MyAllow = "MyAllow";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllow,
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
app.UseCors("MyAllow");
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
