using Microsoft.EntityFrameworkCore;
using SpiceApi.Interface;
using SpiceApi.Repositories;
using SpiceFoodAPi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<CategoryInterface, CategoryRepository>();
builder.Services.AddScoped<SubCategoryInterface, SubCategoryRepository>();
builder.Services.AddScoped<MenuItemInterface, MenuItemRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<SpiceFoodAPIDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddTransient<CategoryInterface, CategoryRepository>();
//builder.Services.AddTransient<MenuItemInterface, MenuItemRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.s
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
