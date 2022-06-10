using GestioneSagre.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestioneSagre.DataAccess.Models.Services.Infrastructure
{
    public partial class GestioneSagreDbContext : DbContext
    {
        public GestioneSagreDbContext(DbContextOptions<GestioneSagreDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Versione> Versioni { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Tabella VERSIONE
            modelBuilder.Entity<Versione>(entity =>
            {
                entity.ToTable("Versione");
                entity.HasKey(versione => versione.Id);
            });
        }
    }
}
