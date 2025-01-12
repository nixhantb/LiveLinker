using LiveLinker.Events.LiveLinker.Events.Core.Interfaces;
using LiveLinker.Events.LiveLinker.Events.Infrastructure.Data;
using LiveLinker.Events.LiveLinker.Events.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;


internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Configuration
     .SetBasePath(Directory.GetCurrentDirectory())
     .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);

        builder.Services.AddScoped<IEventRepository, EventsRepository>();

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

        app.UseHttpsRedirection();

        app.Run();
    }
}
