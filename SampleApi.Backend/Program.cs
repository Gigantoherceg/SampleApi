using Microsoft.EntityFrameworkCore;
using SampleApiBackend.Database;

namespace SampleApiBackend
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            //Configure database
            string connectionString = builder.Configuration.GetConnectionString("Default")
                ?? throw new InvalidOperationException("No connection string");
            builder.Services.AddDbContext<SampleDbContext>(o =>
                o.UseSqlServer(connectionString));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

            app.UseAuthorization();


            app.MapControllers();

            // Database
            using (var scope = app.Services.CreateScope())
            using (var context = scope.ServiceProvider.GetRequiredService<SampleDbContext>())
            {
                await context.Database.MigrateAsync();
            }

            app.Run();
        }
    }
}
