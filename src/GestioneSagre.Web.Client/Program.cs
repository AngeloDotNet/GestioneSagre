namespace GestioneSagre.Web.Client;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

        // Services SCOPED
        builder.Services.Scan(scan => scan.FromAssemblyOf<VersioneService>()
             .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Service")))
             .AsImplementedInterfaces()
             .WithScopedLifetime());

        await builder.Build().RunAsync();
    }
}