using Catalog.API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.API.Infrastructure.DataAccess.EntityConfigurations
{
    class CatalogTrackEntityConf
        : IEntityTypeConfiguration<CatalogTrack>
    {
        public void Configure(EntityTypeBuilder<CatalogTrack> builder)
        {
            builder.ToTable("Catalog");

            builder.Property(ci => ci.Id)
                .ForSqlServerUseSequenceHiLo("catalog_hilo")
                .IsRequired();

            builder.Property(ci => ci.Title)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(ci => ci.CatalogArtist)
                .IsRequired(true);

            //builder.Property(ci => ci.PictureUri)
            //    .IsRequired(false);

            //builder.Ignore(ci => ci.PictureUri);

            //builder.HasOne(ci => ci.CatalogBrand)
            //    .WithMany()
            //    .HasForeignKey(ci => ci.CatalogBrandId);

            //builder.HasOne(ci => ci.CatalogType)
            //    .WithMany()
            //    .HasForeignKey(ci => ci.CatalogTypeId);
        }
    }
}
