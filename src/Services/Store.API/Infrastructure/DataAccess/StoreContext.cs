using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Store.API.Infrastructure.DataAccess.EntityConfigurations;
using Store.API.Models;

namespace Store.API.Infrastructure.DataAccess
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }

        public DbSet<StoreViynl> StoreTracks { get; set; }
        public DbSet<StoreArtist> StoreArtists { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StoreArtitstEntityConf())
                   .ApplyConfiguration(new StoreGenreEntityConf())
                   .ApplyConfiguration(new StoreVinylEntityConf());
        }
    }

    public class StoreContextDesignFactory : IDesignTimeDbContextFactory<StoreContext>
    {
        public StoreContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<StoreContext>()
                .UseSqlServer("Data Source=(localdb)\\v11.0;Initial Catalog=TestDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            return new StoreContext(optionsBuilder.Options);
        }
    }
}
