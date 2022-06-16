﻿namespace GestioneSagre.Business.Extensions;

public static class ConfigureServices
{
    public static IServiceCollection AddConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Services TRANSIENT
        services.Scan(scan => scan.FromAssemblyOf<EfCoreVersioneService>()
            .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Service")))
            .AsImplementedInterfaces()
            .WithTransientLifetime());

        // Services SINGLETON
        services.AddSingleton<IImagePersister, MagickNetImagePersister>();

        return services;
    }
}