namespace GestioneSagre.DataAccess.Models.Services.Interfaces;

public interface ITransactionLogger
{
    Task LogTransactionVersioneCreateAsync(VersioneCreateInputModel inputModel);
    Task LogTransactionLogoEditAsync(LogoEditInputModel inputModel);
    Task LogTransactionFestaCreateAsync(FestaCreateInputModel inputModel);
    Task LogTransactionFestaEditAsync(FestaEditInputModel inputModel);
}