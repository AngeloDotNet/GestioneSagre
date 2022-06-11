namespace GestioneSagre.Business.Services.Application.Versioni;

public class EfCoreVersioneService : IVersioneService
{
    private readonly ILogger<EfCoreVersioneService> logger;
    private readonly GestioneSagreDbContext dbContext;

    public EfCoreVersioneService(ILogger<EfCoreVersioneService> logger, GestioneSagreDbContext dbContext)
    {
        this.logger = logger;
        this.dbContext = dbContext;
    }

    public async Task<ListViewModel<VersioneViewModel>> GetVersioniAsync()
    {
        IQueryable<Versione> baseQuery = dbContext.Versioni;
        baseQuery.OrderByDescending(x => x.Id);

        var queryLinq = baseQuery
            .AsNoTracking();

        var feste = await queryLinq
            .Where(x => x.VersioneStato != VersioneStato.Attiva && x.VersioneStato != VersioneStato.Deprecata)
            .Select(x => VersioneViewModel.FromEntity(x))
            .ToListAsync();

        var totalCount = await queryLinq
            .Where(x => x.VersioneStato != VersioneStato.Attiva && x.VersioneStato != VersioneStato.Deprecata)
            .CountAsync();

        ListViewModel<VersioneViewModel> result = new()
        {
            Results = feste,
            TotalCount = totalCount
        };

        return result;
    }

    public async Task<VersioneViewModel> GetVersioneAsync(string codiceVersione)
    {
        var queryLinq = dbContext.Versioni
            .AsNoTracking()
            .Where(x => x.CodiceVersione == codiceVersione)
            .Select(x => VersioneViewModel.FromEntity(x));

        var viewModel = await queryLinq.FirstOrDefaultAsync();

        return viewModel;
    }

    public async Task<VersioneDetailViewModel> CreateVersioneAsync(VersioneCreateInputModel inputModel)
    {
        string versioneGuid = await GenerateGuid();
        VersioneStato versioneStato = VersioneStato.Attiva;

        Versione versione = new();

        versione.ChangeCodiceVersione(versioneGuid);
        versione.ChangeTestoVersione(inputModel.TestoVersione);
        versione.ChangeVersioneStato(versioneStato);

        dbContext.Add(versione);
        await dbContext.SaveChangesAsync();

        return VersioneDetailViewModel.FromEntity(versione);
    }

    public async Task<bool> IsVersioneAvailableAsync(string testoVersione, int id)
    {
        bool versioneExists = await dbContext.Versioni.AnyAsync(x => EF.Functions.Like(x.TestoVersione, testoVersione) && x.Id != id);
        return !versioneExists;
    }

    public async Task DeleteVersioneAsync(VersioneDeleteInputModel inputModel)
    {
        int IdVersione = await dbContext.Versioni
            .Where(x => x.CodiceVersione == inputModel.CodiceVersione)
            .Select(x => x.Id)
            .FirstOrDefaultAsync();

        Versione versione = await dbContext.Versioni.FindAsync(IdVersione);

        versione.ChangeVersioneStato(VersioneStato.Deprecata);
        await dbContext.SaveChangesAsync();
    }

    public async Task<string> GenerateGuid()
    {
        var newGuid = SequentialGuidGenerator.Instance.NewGuid().ToString();

        return await Task.FromResult(newGuid);
    }
}