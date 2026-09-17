
using Contracts;
using Microsoft.AspNetCore.Mvc;
using UltimateNetFiApi.Extensions;

namespace UltimateNetFiApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.ConfigureCors();
            builder.Services.ConfigureIISIntegration();
            builder.Services.ConfigureRepositoryManager();
            builder.Services.ConfigureLoggerManager();
            builder.Services.ConfigureServiceManager();
            builder.Services.ConfigureSqlContext(builder.Configuration);
            builder.Services.AddAutoMapper(typeof(Program));
            //This configuration is to suppress the automatic model
            //state validation filter that is applied by default in ASP.NET Core.
            //By setting SuppressModelStateInvalidFilter to true, you are telling
            //the framework not to automatically return a 400 Bad 
            //Request response when the model state is invalid. Instead,
            //you can handle model validation errors manually in your controller
            //actions or use custom middleware to handle them as needed.
            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            builder.Services.AddControllers(config =>
            {
                config.RespectBrowserAcceptHeader = true;
                config.ReturnHttpNotAcceptable = true;
            })
                .AddXmlDataContractSerializerFormatters()
                .AddCustomCSVFormatter()
                .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            //var logger = app.Services.GetRequiredService<ILoggerManager>();

            app.ConfigureExceptionHandler();

            if (app.Environment.IsProduction())
                app.UseHsts();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.All
            });

            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
