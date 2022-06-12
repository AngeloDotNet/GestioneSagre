namespace GestioneSagre.Business.Services.Application.Festa;

public class EfCoreFestaService : IFestaService
{
    private readonly ILogger<EfCoreFestaService> logger;
    private readonly GestioneSagreDbContext dbContext;

    public EfCoreFestaService(ILogger<EfCoreFestaService> logger, GestioneSagreDbContext dbContext)
    {
        this.logger = logger;
        this.dbContext = dbContext;
    }

    public async Task<ListViewModel<FestaViewModel>> GetFesteAsync()
    {
        IQueryable<FestaEntity> baseQuery = dbContext.Feste;
        baseQuery.OrderByDescending(x => x.Id);

        var queryLinq = baseQuery
            .Include(festa => festa.Intestazioni)
            .AsNoTracking();

        var feste = await queryLinq
            .Where(x => x.StatusFesta != FestaStato.Eliminata)
            .Select(x => FestaViewModel.FromEntity(x))
            .ToListAsync();

        var totalCount = await queryLinq
            .Where(x => x.StatusFesta != FestaStato.Eliminata)
            .CountAsync();

        ListViewModel<FestaViewModel> result = new()
        {
            Results = feste,
            TotalCount = totalCount
        };

        return result;
    }

    public async Task<FestaDetailViewModel> CreateFestaAsync(FestaCreateInputModel inputModel)
    {
        var festaGuid = SequentialGuidGenerator.Instance.NewGuid().ToString();
        var LogoDefault = "/images/default.png";

        FestaEntity festa = new();

        festa.ChangeDataInizio(inputModel.DataInizio);
        festa.ChangeDataFine(inputModel.DataFine);
        festa.ChangeGuidFesta(festaGuid);

        dbContext.Add(festa);
        await dbContext.SaveChangesAsync();

        IntestazioneEntity intestazione = new();

        intestazione.ChangeFestaId(festa.Id);
        intestazione.ChangeTitolo(inputModel.Titolo);
        intestazione.ChangeEdizione(inputModel.Edizione);
        intestazione.ChangeLuogo(inputModel.Luogo);
        intestazione.ChangeLogo(LogoDefault);

        dbContext.Add(intestazione);
        await dbContext.SaveChangesAsync();

        return FestaDetailViewModel.FromEntity(festa);
    }

    public async Task<FestaDetailViewModel> GetFestaAsync(string guidFesta)
    {
        IQueryable<FestaDetailViewModel> queryLinq = dbContext.Feste
            .Include(festa => festa.Intestazioni)
            .AsNoTracking()
            .Where(festa => festa.GuidFesta == guidFesta)
            .Select(festa => FestaDetailViewModel.FromEntity(festa));

        FestaDetailViewModel viewModel = await queryLinq.FirstOrDefaultAsync();

        return viewModel;
    }

    public async Task<FestaDetailViewModel> EditFestaAsync(FestaEditInputModel inputModel)
    {
        int IdFesta = await dbContext.Feste
            .Where(x => x.GuidFesta == inputModel.GuidFesta)
            .Select(x => x.Id)
            .FirstOrDefaultAsync();

        FestaEntity festa = await dbContext.Feste.FindAsync(IdFesta);

        festa.ChangeDataInizio(inputModel.DataInizio);
        festa.ChangeDataFine(inputModel.DataFine);

        await dbContext.SaveChangesAsync();

        int IdIntestazione = await dbContext.Intestazioni
            .Where(x => x.FestaId == IdFesta)
            .Select(x => x.Id)
            .FirstOrDefaultAsync();

        IntestazioneEntity intestazione = await dbContext.Intestazioni.FindAsync(IdIntestazione);

        intestazione.ChangeTitolo(inputModel.Titolo);
        intestazione.ChangeEdizione(inputModel.Edizione);
        intestazione.ChangeLuogo(inputModel.Luogo);

        await dbContext.SaveChangesAsync();

        return FestaDetailViewModel.FromEntity(festa);
    }
    public async Task DeleteFestaAsync(FestaDeleteInputModel inputModel)
    {
        int IdFesta = await dbContext.Feste
            .Where(x => x.GuidFesta == inputModel.GuidFesta)
            .Select(x => x.Id)
            .FirstOrDefaultAsync();

        FestaEntity festa = await dbContext.Feste.FindAsync(IdFesta);

        festa.ChangeStatusFesta(FestaStato.Eliminata);
        await dbContext.SaveChangesAsync();
    }
}