namespace GestioneSagre.Business.Extensions;

public static class ApplicationServices
{
    public static IApplicationBuilder UseApplicationServices(this IApplicationBuilder app)
    {
        app.UseHttpsRedirection();

        app.UseStaticFiles();
        app.UseRouting();

        app.UseCors();

        return app;
    }
}
