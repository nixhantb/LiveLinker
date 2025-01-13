using FluentValidation;
using LiveLinker.Events.LiveLinker.Events.Core.Entities;
using LiveLinker.Events.LiveLinker.Events.Core.Interfaces;
using LiveLinker.Events.LiveLinker.Events.Infrastructure.Data;
using LiveLinker.Events.LiveLinker.Events.Infrastructure.Repository;
using LiveLinker.Events.LiveLinker.Events.Validators;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

builder.Configuration
.SetBasePath(Directory.GetCurrentDirectory())
.AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);

builder.Services.AddControllers();

builder.Services.AddValidatorsFromAssemblyContaining<EventsValidator>(); 
builder.Services.AddScoped<IEventRepository, EventsRepository>();
builder.Services.AddScoped<IValidator<Event>, EventsValidator>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BaseDbContext>(options =>
 {
     var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
     options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
 });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapControllers();
app.UseHsts();
app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.Run();
