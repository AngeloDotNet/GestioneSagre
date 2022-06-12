namespace GestioneSagre.Business.Services.Application.Festa;

public interface IFestaService
{
    Task<ListViewModel<FestaViewModel>> GetFesteAsync();
    Task<FestaDetailViewModel> CreateFestaAsync(FestaCreateInputModel inputModel);
    Task<FestaDetailViewModel> GetFestaAsync(string guidFesta);
    Task<FestaDetailViewModel> EditFestaAsync(FestaEditInputModel inputModel);
    Task DeleteFestaAsync(FestaDeleteInputModel inputModel);
}