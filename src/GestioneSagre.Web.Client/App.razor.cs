namespace GestioneSagre.Web.Client;

public class AppBase : ComponentBase, IDisposable
{
    [Inject] private LazyAssemblyLoader AssemblyLoader { get; set; }
    [Inject] private ILogger<App> Logger { get; set; }

    protected readonly List<Assembly> LazyLoadedAssemblies = new();

    protected async Task OnNavigateAsync(NavigationContext args)
    {
        try
        {
            switch (args.Path)
            {
                //case "fetchdata":
                //    {
                //        var assemblies = await AssemblyLoader.LoadAssembliesAsync(new List<string>
                //        {
                //            "GestioneSagre.Web.Client.WeatherForecast.dll"
                //        });
                //        LazyLoadedAssemblies.AddRange(assemblies);
                //        break;
                //    }

                default:
                    {
                        var assemblies = await AssemblyLoader.LoadAssembliesAsync(new List<string>
                        {
                            "GestioneSagre.Web.Client.UI.dll"
                        });

                        LazyLoadedAssemblies.AddRange(assemblies);
                        break;
                    }
            }
        }
        catch (Exception ex)
        {
            Logger.LogError($"Error Loading spares page: {ex}");
        }
    }

    public void Dispose(bool disposing)
    {
        if (disposing)
        {
        }
    }

    public void Dispose()
    {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }

    ~AppBase()
    {
        this.Dispose(false);
    }
}