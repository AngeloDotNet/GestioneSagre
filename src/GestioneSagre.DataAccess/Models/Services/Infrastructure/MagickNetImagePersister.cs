namespace GestioneSagre.DataAccess.Models.Services.Infrastructure;
public class MagickNetImagePersister : IImagePersister
{
    private readonly IHostingEnvironment env;

    private readonly SemaphoreSlim semaphore;

    public MagickNetImagePersister(IHostingEnvironment env)
    {
        ResourceLimits.Height = 4000;
        ResourceLimits.Width = 4000;

        semaphore = new SemaphoreSlim(1);
        this.env = env;
    }

    public async Task<string> SaveLogoAsync(int festaId, IFormFile formFile)
    {
        await semaphore.WaitAsync();

        try
        {
            string path = $"/images/festa-{festaId}.jpg";
            string physicalPath = Path.Combine(env.ContentRootPath, "images", $"festa-{festaId}.jpg");

            if (!Directory.Exists(Path.GetDirectoryName(physicalPath)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(physicalPath));
            }

            using Stream inputStream = formFile.OpenReadStream();
            using MagickImage image = new(inputStream);

            int width = 300;
            int height = 300;

            MagickGeometry resizeGeometry = new(width, height)
            {
                FillArea = true
            };

            image.Resize(resizeGeometry);
            image.Crop(width, width, Gravity.Northwest);

            image.Quality = 70;
            image.Write(physicalPath, MagickFormat.Jpg);

            return path;
        }
        finally
        {
            semaphore.Release();
        }
    }
}