// See https://aka.ms/new-console-template for more information
using Day1;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var builder = Host.CreateApplicationBuilder(args);
//builder.Services.AddMemoryCache();
builder.Services.AddScoped<IMemoryCache, MemoryCache>();
builder.Services.AddScoped<Day7>();

var app = builder.Build();

var day7 = app.Services.GetRequiredService<Day7>();
day7.Execute();

//Day1.Day1.Execute();
//Day2.Execute();