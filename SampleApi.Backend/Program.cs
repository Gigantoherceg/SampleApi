using Microsoft.EntityFrameworkCore;
using SampleApiBackend.Database;
using SampleApiBackend.Repository;
using SampleApiBackend.Services;

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
            builder.Services.AddDbContext<SoapDbContext>(o => o.UseSqlServer(connectionString));

            builder.Services.AddScoped<ISoapService, SoapService>();
            builder.Services.AddScoped<ISoapRepository, SoapRepository>();

            builder.Services.AddCors(o => o
                    .AddDefaultPolicy(p => p
                      .AllowAnyMethod()
                      .AllowAnyHeader()
                      .WithOrigins("http://localhost:4200")));

            builder.Services.AddControllers(o => o.SuppressAsyncSuffixInActionNames = false);

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseCors();

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
            using (var context = scope.ServiceProvider.GetRequiredService<SoapDbContext>())
            {
                await context.Database.MigrateAsync();
            }

            app.Run();
        }
    }
}
