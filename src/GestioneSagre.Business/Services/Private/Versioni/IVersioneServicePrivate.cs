namespace GestioneSagre.Business.Services.Private.Versioni;

public interface IVersioneServicePrivate
{
    Task<ListViewModel<VersioneViewModel>> GetVersioniAsync();
    Task<VersioneViewModel> GetVersioneAsync(string CodiceVersione);
    Task<VersioneDetailViewModel> CreateVersioneAsync(VersioneCreateInputModel inputModel);
    Task<bool> IsVersioneAvailableAsync(string title, int excludeId);
    Task DeleteVersioneAsync(VersioneDeleteInputModel inputModel);
    Task<string> GenerateGuid();
}
