namespace GestioneSagre.DataAccess.Models.Services.Infrastructure;

public interface IImagePersister
{
    Task<string> SaveLogoAsync(int festaId, IFormFile formFile);
}