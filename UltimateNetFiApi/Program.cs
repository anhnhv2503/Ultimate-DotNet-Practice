
using Contracts;
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
