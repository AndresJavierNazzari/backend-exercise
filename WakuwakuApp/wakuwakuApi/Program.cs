using Asp.Versioning;
using Microsoft.AspNetCore.ResponseCompression;
using FluentValidation.AspNetCore;

using wakuwakuApi.Persistence;
using wakuwakuApi.Persistence.Interfaces;
using wakuwakuApi.Repositories.Interfaces;
using wakuwakuApi.Repositories;
using wakuwakuApi.Services.Interfaces;
using wakuwakuApi.Services;
using wakuwakuApi.Middlewares;
using FluentValidation;
using wakuwakuApi.Models;
using wakuwakuApi.Validators;


namespace wakuwakuApi {
    public class Program {
        public static void Main(string[] args) {

            // ***********  BUILDER ************
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // ***********  GZIP COMPRESSION ************
            builder.Services.AddResponseCompression(options => {
                options.EnableForHttps = true;
                options.Providers.Add<GzipCompressionProvider>();
            });

            // ***********  EXCEPTIONS ************
            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
            builder.Services.AddProblemDetails();

            // ***********  API VERSIONING ************
            var apiVersioningBuilder = builder.Services.AddApiVersioning(setupAction => {
                setupAction.AssumeDefaultVersionWhenUnspecified = true;
                setupAction.DefaultApiVersion = new ApiVersion(1, 0);
                setupAction.ReportApiVersions = true;

            });
            apiVersioningBuilder.AddApiExplorer(options => {
                // add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
                // note: the specified format code will format the version as "'v'major[.minor][-status]"
                options.GroupNameFormat = "'v'VVV";

                // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
                // can also be used to control the format of the API version in route templates
                options.SubstituteApiVersionInUrl = true;
            });

            // ***********  FLUENT VALIDATION ************
            builder.Services.AddFluentValidationAutoValidation();

            // ***********  DEPENDENCY INJECTION ************
            // Persistance
            builder.Services.AddSingleton<IInMemoryPersistenceService, InMemoryPersistenceService>();

            // Repositories
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IGoalRepository, GoalRepository>();

            // Services
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IGoalService, GoalService>();

            // Validators
            builder.Services.AddScoped<IValidator<GoalCreate>, GoalValidator>();
            builder.Services.AddScoped<IValidator<CategoryCreate>, CategoryValidator>();

            // ***********  HEALTHCHECK ************
            builder.Services.AddHealthChecks();

            // ********************************** //
            // ***********  PIPELINE ************ //
            // ********************************** //
            var app = builder.Build();
            app.UseResponseCompression();

            // Configure the HTTP request pipeline.
            if(app.Environment.IsDevelopment()) {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseExceptionHandler();
            app.UseRouting();
            app.UseAuthorization();
            app.MapControllers();
            app.MapHealthChecks("/health");
            app.Run();
        }

    }
}
