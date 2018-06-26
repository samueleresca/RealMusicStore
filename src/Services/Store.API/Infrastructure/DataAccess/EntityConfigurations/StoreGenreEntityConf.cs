using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.API.Models;

namespace Store.API.Infrastructure.DataAccess.EntityConfigurations
{
    class StoreGenreEntityConf
        : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("Genre");

            builder.Property(ci => ci.Id)
                .ForSqlServerUseSequenceHiLo("genre_hilo")
                .IsRequired();

            builder.Property(ci => ci.Title)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(ci => ci.Description)
                .IsRequired();

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
