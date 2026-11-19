
using Data;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
builder.Services.AddOptions<ScalarOptions>().BindConfiguration("Scalar");
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(o =>
o.UseNpgsql(builder.Configuration.GetConnectionString("Connection")));
builder.Services.AddOpenApi();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())

{
    app.UseStaticFiles();
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseSession();
app.MapControllers();
app.Run();


