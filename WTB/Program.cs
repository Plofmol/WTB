using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using WTB;

var builder = WebApplication.CreateBuilder(args);

// Set up your database connection string
var connectionString = "Data Source=(localdb)\\\\Local;Initial Catalog=ormtest;Integrated Security=True\"";

// Add services
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllers();

// Add Swagger configuration
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "WTB", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "WTB V1");
    });
}
else
{
    // Add any necessary production middleware here
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();
// test voor hosting

app.Run();

