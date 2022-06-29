namespace GestioneSagre.Business.Extensions;

public static class ConfigureServices
{
    public static IServiceCollection AddConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Services TRANSIENT
        services.Scan(scan => scan.FromAssemblyOf<EfCoreFestaService>()
            .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Service")))
            .AsImplementedInterfaces()
            .WithTransientLifetime());

        // Services SINGLETON
        services.AddSingleton<IImagePersister, MagickNetImagePersister>();
        services.AddSingleton<ITransactionLogger, LocalTransactionLogger>();

        return services;
    }

    public static IServiceCollection AddConfigPrivateServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Services TRANSIENT
        services.Scan(scan => scan.FromAssemblyOf<EfCoreVersioneServicePrivate>()
            .AddClasses(classes => classes.Where(type => type.Name.EndsWith("ServicePrivate")))
            .AsImplementedInterfaces()
            .WithTransientLifetime());

        return services;
    }
}