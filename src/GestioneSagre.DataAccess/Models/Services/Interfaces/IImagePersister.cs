namespace GestioneSagre.DataAccess.Models.Services.Interfaces;

public interface IImagePersister
{
    Task<string> SaveLogoAsync(int festaId, IFormFile formFile);
}