using Microsoft.EntityFrameworkCore;

namespace GestioneSagre.DataAccess.Models.Services.Infrastructure
{
    public partial class GestioneSagreDbContext : DbContext
    {
        public GestioneSagreDbContext(DbContextOptions<GestioneSagreDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
