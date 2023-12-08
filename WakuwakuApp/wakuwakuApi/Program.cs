using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Reflection;
using wakuwakuApi.Persistence;
using wakuwakuApi.Persistence.Interfaces;
using wakuwakuApi.Repositories.Interfaces;
using wakuwakuApi.Repositories;
using wakuwakuApi.Services.Interfaces;
using wakuwakuApi.Services;
using wakuwakuApi.Middlewares;

namespace wakuwakuApi {
    public class Program {


        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddControllers().AddNewtonsoftJson();
            builder.Services.AddSingleton<IInMemoryPersistenceService, InMemoryPersistenceService>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();

            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

            var app = builder.Build();

            // GlobalExceptionHandler.ConfigureExceptionHandler(app);

            // Configure the HTTP request pipeline.
            if(app.Environment.IsDevelopment()) {
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




