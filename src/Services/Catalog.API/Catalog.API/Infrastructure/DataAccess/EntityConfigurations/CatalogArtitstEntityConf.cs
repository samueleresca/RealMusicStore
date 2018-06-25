using Catalog.API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.API.Infrastructure.DataAccess.EntityConfigurations
{
    class CatalogArtitstEntityConf
        : IEntityTypeConfiguration<CatalogArtist>
    {
        public void Configure(EntityTypeBuilder<CatalogArtist> builder)
        {
            builder.ToTable("CatalogArtist");

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
