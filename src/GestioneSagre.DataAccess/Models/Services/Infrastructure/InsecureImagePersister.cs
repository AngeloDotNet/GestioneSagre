namespace GestioneSagre.DataAccess.Models.Services.Infrastructure;

public class InsecureImagePersister : IImagePersister
{
    private readonly IHostingEnvironment env;

    public InsecureImagePersister(IHostingEnvironment env)
    {
        this.env = env;
    }

    public async Task<string> SaveLogoAsync(int festaId, IFormFile formFile)
    {
        string path = $"/images/festa-{festaId}.jpg";
        string physicalPath = Path.Combine(env.WebRootPath, "images", $"festa-{festaId}.jpg");
        using FileStream fileStream = File.OpenWrite(physicalPath);

        await formFile.CopyToAsync(fileStream);

        return path;
    }
}