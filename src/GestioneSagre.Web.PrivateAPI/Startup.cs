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

        services.AddDbContextPool<GestioneSagreDbContext>(optionBuilder =>
        {
            var maxRetryCount = Configuration.GetSection("Database").GetValue<int>("maxRetryCount");
            var maxRetryDelay = TimeSpan.FromSeconds(Configuration.GetSection("Database").GetValue<double>("maxRetryDelay"));

            var connectionString = Configuration.GetSection("ConnectionStrings").GetValue<string>("Default");
            optionBuilder.UseSqlServer(connectionString, options =>
            {
                options.EnableRetryOnFailure(maxRetryCount, maxRetryDelay, null);
            });
        });

        // Services - Custom Extension Method
        services.AddPrivateServices(Configuration);
        services.AddSwaggerServices(Configuration);
        services.AddPrivateSenders(Configuration);

        // Options
        services.Configure<KestrelServerOptions>(Configuration.GetSection("Kestrel"));
        services.Configure<SmtpOptions>(Configuration.GetSection("Smtp"));
    }

    public void Configure(WebApplication app)
    {
        IWebHostEnvironment env = app.Environment;

        var enableSwagger = Configuration.GetSection("Swagger").GetValue<bool>("enabled");

        if (enableSwagger)
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
