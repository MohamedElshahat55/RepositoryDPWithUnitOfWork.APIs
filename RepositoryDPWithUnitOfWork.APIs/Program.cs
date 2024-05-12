using Microsoft.EntityFrameworkCore;
using RepositoryDPWithUnitOfWork.Core.Interfaces;
using RepositoryDPWithUnitOfWork.EF.Data;
using RepositoryDPWithUnitOfWork.EF.Repositories;

namespace RepositoryDPWithUnitOfWork.APIs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Add Connection String
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                    b=>b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
            });
            
            // Allow DI 
            builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));

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
        }
    }
}
