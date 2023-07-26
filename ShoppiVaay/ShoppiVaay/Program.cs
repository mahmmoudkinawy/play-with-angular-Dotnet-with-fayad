using Microsoft.EntityFrameworkCore;
using ShoppiVaay.DbContexts;
using ShoppiVaay.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ShoppiVayDbContext>(options =>
    options.UseSqlite("Data Source=ShoppiVaay.db"));

builder.Services.AddScoped<IProductRepository, ProductRepository>();

var con1 = builder.Configuration.GetConnectionString("DefaultConnection");
var con2 = builder.Configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
var con3 = builder.Configuration.GetSection("ConnectionStrings:DefaultConnection");

builder.Services.AddCors(options =>
{
    options.AddPolicy("Client", policy =>
    {
        policy
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
            .WithOrigins("http://localhost:4200");
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("Client");

app.UseHttpsRedirection();

app.MapControllers();

using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<ShoppiVayDbContext>();
await Seed.SeedProductsAsync(dbContext);

app.Run();
