using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace GestioneSagre.Web.Server;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews();
        services.AddRazorPages();

        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
            });
        });

        services.AddDbContextPool<GestioneSagreDbContext>(optionBuilder =>
        {
            string connectionString = Configuration.GetSection("ConnectionStrings").GetValue<string>("Default");
            optionBuilder.UseSqlServer(connectionString);
        });

        services.AddTransient<IVersioneService, EfCoreVersioneService>();
        services.AddTransient<IFestaService, EfCoreFestaService>();

        // Options
        services.Configure<KestrelServerOptions>(Configuration.GetSection("Kestrel"));

        services.AddSwaggerGen(config =>
        {
            config.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Gestione Sagre",
                Version = "v1",
                Description = "API that allows the management of festivals management",
                // TermsOfService = new Uri("https://example.com/terms"), 

                //Contact = new OpenApiContact
                //{
                //    Name = "Nominativo contatto",
                //    Email = "Email contatto",
                //    Url = new Uri("https://twitter.com/username-contatto"),
                //},

                // License = new OpenApiLicense
                // {
                //     Name = "Nome licenza API",
                //     Url = new Uri("https://example.com/license"),
                // }
            });
        });
    }
    public void Configure(WebApplication app)
    {
        IWebHostEnvironment env = app.Environment;

        if (env.IsDevelopment())
        {
            app.UseWebAssemblyDebugging();

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Gestione Sagre v1"));
        }

        app.UseHttpsRedirection();
        app.UseBlazorFrameworkFiles();

        app.UseStaticFiles();
        app.UseRouting();

        app.UseCors("CorsPolicy");
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapRazorPages();
            endpoints.MapControllers();
            endpoints.MapFallbackToFile("index.html");
        });
    }
}