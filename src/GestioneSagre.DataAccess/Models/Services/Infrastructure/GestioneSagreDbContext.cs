namespace GestioneSagre.DataAccess.Models.Services.Infrastructure;

public partial class GestioneSagreDbContext : DbContext
{
    public GestioneSagreDbContext(DbContextOptions<GestioneSagreDbContext> options) : base(options)
    {
    }

    public virtual DbSet<FestaEntity> Feste { get; set; }
    public virtual DbSet<IntestazioneEntity> Intestazioni { get; set; }
    public virtual DbSet<VersioneEntity> Versioni { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

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
    }
}
