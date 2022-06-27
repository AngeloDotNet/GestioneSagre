using GestioneSagre.DataAccess.Models.Services.Interfaces;

namespace GestioneSagre.Business.Services.Application.Logo;
public class EfCoreLogoService : ILogoService
{
    private readonly ILogger<EfCoreLogoService> logger;
    private readonly GestioneSagreDbContext dbContext;
    private readonly IImagePersister imagePersister;

    public EfCoreLogoService(ILogger<EfCoreLogoService> logger, GestioneSagreDbContext dbContext, IImagePersister imagePersister)
    {
        this.logger = logger;
        this.dbContext = dbContext;
        this.imagePersister = imagePersister;
    }

    public async Task UploadLogoAsync(LogoEditInputModel inputModel)
    {
        int IdFesta = await dbContext.Feste
            .Where(x => x.GuidFesta == inputModel.GuidFesta)
            .Select(x => x.Id)
            .FirstOrDefaultAsync();

        int IdIntestazione = await dbContext.Intestazioni
            .Where(x => x.FestaId == IdFesta)
            .Select(x => x.Id)
            .FirstOrDefaultAsync();

        IntestazioneEntity intestazione = await dbContext.Intestazioni.FindAsync(IdIntestazione);

        string imagePath = await imagePersister.SaveLogoAsync(IdFesta, inputModel.Logo);

        intestazione.ChangeLogo(imagePath);

        await dbContext.SaveChangesAsync();
    }
}
