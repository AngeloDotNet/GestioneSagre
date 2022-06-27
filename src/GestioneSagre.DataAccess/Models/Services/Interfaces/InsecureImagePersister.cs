namespace GestioneSagre.DataAccess.Models.Services.Interfaces;

public class InsecureImagePersister : IImagePersister
{
    private readonly IHostingEnvironment env;

    public InsecureImagePersister(IHostingEnvironment env)
    {
        this.env = env;
    }

    public async Task<string> SaveLogoAsync(int festaId, IFormFile formFile)
    {
        var path = $"/images/festa-{festaId}.jpg";
        var physicalPath = Path.Combine(env.WebRootPath, "images", $"festa-{festaId}.jpg");
        using var fileStream = File.OpenWrite(physicalPath);

        await formFile.CopyToAsync(fileStream);

        return path;
    }
}