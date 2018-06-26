using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.API.Models;

namespace Store.API.Infrastructure.DataAccess.EntityConfigurations
{
    class StoreArtitstEntityConf
        : IEntityTypeConfiguration<StoreArtist>
    {
        public void Configure(EntityTypeBuilder<StoreArtist> builder)
        {
            builder.ToTable("StoreArtist");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
               .ForSqlServerUseSequenceHiLo("catalog_artist_hilo")
               .IsRequired();

            builder.Property(cb => cb.ArtistName)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
