using Infra.Services.Classes;
using Infra.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProductService, ProductService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//GetSalesSummary
app.MapGet("/GetSalesSummary", async Task<IResult> (IProductService productService) =>
{
    return Results.Ok(await productService.GetSalesSummaryAsync());
})
.WithName("GetSalesSummary")
.WithOpenApi();



//OrderByProductname
app.MapGet("/OrderByProductname", async Task<IResult> (IProductService productService) =>
{
    return Results.Ok(await productService.GetSalesByName());
})
.WithName("OrderByProductname")
.WithOpenApi();

//GetByQuantity
app.MapGet("/GetByQuantity", async Task<IResult> (IProductService productService) =>
{
    return Results.Ok(await productService.GetByQuantity());
})
.WithName("GetByQuantity")
.WithOpenApi();

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
