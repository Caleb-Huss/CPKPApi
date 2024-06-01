using CPKPDL;
using CPKPBL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
//var AllowedOrigins = "_allowedOrigins";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CpkpDbContext>(options => options.UseSqlServer("name=ConnectionStrings:CPKPDB"));
builder.Services.AddScoped<IDL, DL>();
builder.Services.AddScoped<IBL, BL>();

//builder.Services.AddCors(options =>
//{
//    options.AddDefaultPolicy(policy =>
//        {
//            policy.WithOrigins("https://cpkp.calebhuss.com", "http://localhost:4200", "https://*.calebhuss.com")
//            .AllowAnyHeader()
//            .AllowAnyMethod();
//        });
//}
//);
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy((policy) =>
    {
        policy.SetIsOriginAllowedToAllowWildcardSubdomains()
        .WithOrigins("https://cpkp.calebhuss.com", "http://localhost:4200", "https://*.calebhuss.com")
        .AllowAnyHeader()
        .AllowAnyMethod();
    }
    );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
/*app.UseSwagger();
app.UseSwaggerUI();*/

app.UseHttpsRedirection();

app.UseRouting();

//app.UseCors(AllowedOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
