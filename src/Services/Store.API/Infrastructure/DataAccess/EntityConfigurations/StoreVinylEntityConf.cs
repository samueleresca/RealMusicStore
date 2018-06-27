using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.API.Models;

namespace Store.API.Infrastructure.DataAccess.EntityConfigurations
{
    class StoreVinylEntityConf
        : IEntityTypeConfiguration<StoreViynl>
    {
        public void Configure(EntityTypeBuilder<StoreViynl> builder)
        {
            builder.ToTable("StoreVinyl");

            builder.Property(ci => ci.Id)
                .ForSqlServerUseSequenceHiLo("catalog_hilo")
                .IsRequired();

            builder.Property(ci => ci.Title)
                .IsRequired()
                .HasMaxLength(50);


            builder.HasOne(ci => ci.Artist)
                .WithMany()
                .HasForeignKey(ci => ci.ArtistId);

            builder.HasOne(ci => ci.Genre)
             .WithMany()
             .HasForeignKey(ci => ci.GenreId);

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
