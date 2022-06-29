namespace GestioneSagre.Web.PrivateAPI;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {

        services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
            });

        services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder.AllowAnyOrigin();
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
            });
        });

        // Services - Custom Extension Method
        services.AddConfigPrivateServices(Configuration);
        services.AddSwaggerServices(Configuration);

        // Options
        services.Configure<KestrelServerOptions>(Configuration.GetSection("Kestrel"));
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(WebApplication app)
    {
        IWebHostEnvironment env = app.Environment;

        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Gestione Sagre v1"));
        }

        app.UseAppPrivateServices(); // Custom Extension Method

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
