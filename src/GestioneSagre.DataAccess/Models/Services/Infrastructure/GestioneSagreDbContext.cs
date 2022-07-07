namespace GestioneSagre.DataAccess.Models.Services.Infrastructure;

public partial class GestioneSagreDbContext : DbContext
{
    public GestioneSagreDbContext(DbContextOptions<GestioneSagreDbContext> options) : base(options)
    {
    }

    public virtual DbSet<FestaEntity> Feste { get; set; }
    public virtual DbSet<IntestazioneEntity> Intestazioni { get; set; }
    public virtual DbSet<VersioneEntity> Versioni { get; set; }
    public virtual DbSet<CategoriaEntity> Categorie { get; set; }
    public virtual DbSet<ProdottoEntity> Prodotti { get; set; }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<Currency>().HaveConversion<string>();
        configurationBuilder.Properties<decimal>().HaveConversion<float>();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //Mapping per gli owned types
        modelBuilder.Owned<Money>();

        //Tabella FESTA
        modelBuilder.Entity<FestaEntity>(entity =>
        {
            entity.ToTable("Festa");
            entity.HasKey(festa => festa.Id);

            entity.HasMany(festa => festa.Intestazioni)
                   .WithOne(intestazione => intestazione.Festa)
                   .HasForeignKey(intestazione => intestazione.FestaId);
        });

        //Tabella INTESTAZIONE
        modelBuilder.Entity<IntestazioneEntity>(entity =>
        {
            entity.ToTable("Intestazione");
            entity.HasKey(intestazione => intestazione.Id);
        });

        //Tabella VERSIONE
        modelBuilder.Entity<VersioneEntity>(entity =>
        {
            entity.ToTable("Versione");
            entity.HasKey(versione => versione.Id);
        });

        //Tabella CATEGORIE
        modelBuilder.Entity<CategoriaEntity>(entity =>
        {
            entity.ToTable("Categoria");
            entity.HasKey(categoria => categoria.Id);

            entity.HasMany(categoria => categoria.Prodotti)
                   .WithOne(prodotto => prodotto.Categoria)
                   .HasForeignKey(prodotto => prodotto.CategoriaId);
        });

        //Tabella PRODOTTO
        modelBuilder.Entity<ProdottoEntity>(entity =>
        {
            entity.ToTable("Prodotto");
            entity.HasKey(prodotto => prodotto.Id);
        });
    }
}
