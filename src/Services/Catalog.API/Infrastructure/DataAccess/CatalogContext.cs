using Catalog.API.Infrastructure.DataAccess.EntityConfigurations;
using Catalog.API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Catalog.API.Infrastructure.DataAccess
{

    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions<CatalogContext> options) : base(options)
        {
        }

        public DbSet<CatalogTrack> CatalogTracks { get; set; }
        public DbSet<CatalogArtist> CatalogArtists { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CatalogArtitstEntityConf())
                   .ApplyConfiguration(new CatalogGenreEntityConf())
                   .ApplyConfiguration(new CatalogTrackEntityConf());
        }
    }


    public class CatalogContextDesignFactory : IDesignTimeDbContextFactory<CatalogContext>
    {
        public CatalogContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CatalogContext>()
                .UseSqlServer("Data Source=localhost,1433;Initial Catalog=Test;Integrated Security=False;User ID=sa;Password=P@55w0rd");

            return new CatalogContext(optionsBuilder.Options);
        }
    }
}
