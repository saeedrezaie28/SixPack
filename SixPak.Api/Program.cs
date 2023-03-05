

using Microsoft.AspNetCore.Http.Json;
using SixPack.Infrastructure;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using System.Text.Json;
using SixPack.Apllication;
using SixPack.Domain.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProdcutServices, SixPack.Apllication.ProdcutServices>();
builder.Services.AddScoped<IProdcutRepository, SixPack.Infrastructure.ProdcutRepository>();
builder.Services.AddScoped<IUnitOfWork, SixPack.Infrastructure.SixPackDB>();


//add dbContext
builder.Services.AddSqlServer<SixPackDB>(builder.Configuration.GetConnectionString("default"));

//json

builder.Services.Configure<JsonOptions>(opt =>
{
    opt.SerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});

var app = builder.Build();

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
