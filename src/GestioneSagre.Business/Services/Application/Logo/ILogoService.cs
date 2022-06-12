namespace GestioneSagre.Business.Services.Application.Logo;
public interface ILogoService
{
    public Task UploadLogoAsync(LogoEditInputModel inputModel);
}
