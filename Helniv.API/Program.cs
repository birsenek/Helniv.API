using Helniv.API.Entities;
using Helniv.API.Services;
using Helniv.API.Utils;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//var HelnivPolicy = "_helnivPolicy";
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<CardsDbContext>(options =>
    options.UseNpgsql(connectionString));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<ICardService, CardService>();


builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options => options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
});

var app = builder.Build();

app.UseRouting();
app.UseCors("AllowOrigin");
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapGet("/cards", async context =>
    {
        await context.Response.WriteAsync("Hello World!");
    });
});
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    ///minmal api controller:
    //app.MapGet("/cards", async (CardsDbContext db) => await db.Cards.ToListAsync());
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.MapControllers();


app.Run();
