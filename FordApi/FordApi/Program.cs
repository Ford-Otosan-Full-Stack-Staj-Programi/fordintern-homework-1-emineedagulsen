using FluentValidation;
using FluentValidation.AspNetCore;
using FordApi;
using FordApi.Data;
using FordApi.Data.Context;
using FordApi.Data.Repository.Abstract;
using FordApi.Data.Repository.Concrete;
using FordApi.Data.UnitOfWork.Abstract;
using FordApi.Data.UnitOfWork.Concrete;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
//register the fluent validator manually
builder.Services.AddControllers().AddFluentValidation();
builder.Services.AddTransient<IValidator<Staff>, StaffValidator>();
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();
//Bu kýsýmda ilgili providerý kullanarak 
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseOracle(configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
// Swagger/OpenAPI support
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
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();