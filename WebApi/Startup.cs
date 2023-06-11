using Application;
using Persistence;

namespace WebApi;

public class Startup
{
    private IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddPersistenceLayer(Configuration);
        services.AddApplicationLayer();

        services
            .AddControllers()
            .AddJsonOptions(builder =>
            {
                builder.JsonSerializerOptions.PropertyNamingPolicy = null; // PascalCase стиль свойств в ответе
                // builder.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });

        services.AddCors(options => options.AddPolicy("CorsAllowAll", policyBuilder =>
        {
            policyBuilder
                .AllowAnyOrigin() // https://developer.mozilla.org/ru/docs/Web/HTTP/Headers/Access-Control-Allow-Origin
                .AllowAnyMethod()
                .AllowAnyHeader();
            // .AllowCredentials()
            // .WithExposedHeaders("*") // https://developer.mozilla.org/ru/docs/Web/HTTP/Headers/Access-Control-Allow-Headers
        }));
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();
        app.UseCors("CorsAllowAll");
        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}