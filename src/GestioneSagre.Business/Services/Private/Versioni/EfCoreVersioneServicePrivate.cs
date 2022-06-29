namespace GestioneSagre.Business.Services.Private.Versioni;

public class EfCoreVersioneServicePrivate : IVersioneServicePrivate
{
    private readonly ILogger<EfCoreVersioneServicePrivate> logger;
    private readonly GestioneSagreDbContext dbContext;

    public EfCoreVersioneServicePrivate(ILogger<EfCoreVersioneServicePrivate> logger, GestioneSagreDbContext dbContext)
    {
        this.logger = logger;
        this.dbContext = dbContext;
    }

    public async Task<ListViewModel<VersioneViewModel>> GetVersioniAsync()
    {
        IQueryable<VersioneEntity> baseQuery = dbContext.Versioni;
        baseQuery.OrderByDescending(x => x.Id);

        var queryLinq = baseQuery
            .AsNoTracking();

        var versioni = await queryLinq
            .Select(x => VersioneViewModel.FromEntity(x))
            .ToListAsync();

        var totalCount = await queryLinq
            .CountAsync();

        ListViewModel<VersioneViewModel> result = new()
        {
            Results = versioni,
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
        var versioneGuid = await GenerateGuid();
        var versioneStato = VersioneStato.Attiva;

        VersioneEntity versione = new();

        versione.ChangeCodiceVersione(versioneGuid);
        versione.ChangeTestoVersione(inputModel.TestoVersione);
        versione.ChangeVersioneStato(versioneStato);

        dbContext.Add(versione);
        await dbContext.SaveChangesAsync();

        return VersioneDetailViewModel.FromEntity(versione);
    }

    public async Task<bool> IsVersioneAvailableAsync(string testoVersione, int id)
    {
        var versioneExists = await dbContext.Versioni.AnyAsync(x => EF.Functions.Like(x.TestoVersione, testoVersione) && x.Id != id);
        return !versioneExists;
    }

    public async Task DeleteVersioneAsync(VersioneDeleteInputModel inputModel)
    {
        var IdVersione = await dbContext.Versioni
            .Where(x => x.CodiceVersione == inputModel.CodiceVersione)
            .Select(x => x.Id)
            .FirstOrDefaultAsync();

        var versione = await dbContext.Versioni.FindAsync(IdVersione);

        versione.ChangeVersioneStato(VersioneStato.Deprecata);
        await dbContext.SaveChangesAsync();
    }

    public async Task<string> GenerateGuid()
    {
        var newGuid = SequentialGuidGenerator.Instance.NewGuid().ToString();

        return await Task.FromResult(newGuid);
    }
}