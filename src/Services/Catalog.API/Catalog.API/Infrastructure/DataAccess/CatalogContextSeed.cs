using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Catalog.API.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Catalog.API.Infrastructure.DataAccess
{
    public class CatalogContextSeed
    {
        public async Task SeedAsync(CatalogContext context, IHostingEnvironment env, ILogger<CatalogContextSeed> logger)
        {

            if (!context.Genres.Any())
            {
                await context.Genres.AddRangeAsync(GetPreconfiguredCatalogGenres());
                await context.SaveChangesAsync();
            }

            if (!context.CatalogArtists.Any())
            {
                await context.CatalogArtists.AddRangeAsync(GetPreconfiguredCatalogArtists());
                await context.SaveChangesAsync();
            }

            if (!context.CatalogTracks.Any())
            {
                await context.CatalogTracks.AddRangeAsync(GetPreconfiguredCatalogTracks());
                await context.SaveChangesAsync();

            }

        }

        private IEnumerable<Genre> GetPreconfiguredCatalogGenres()
        {
            return new List<Genre>()
            {
                new Genre { Id= 1, Title = "Hip/Hop", Description = ""},
                new Genre  {Id= 2,Title = "Rap", Description = ""},
                new Genre  {Id = 3, Title = "Classic", Description = ""},
                new Genre  {Id = 4, Title = "Jazz", Description = ""}
            };
        }


        private IEnumerable<CatalogArtist> GetPreconfiguredCatalogArtists()
        {
            return new List<CatalogArtist>()
            {
                new CatalogArtist {  Id= 1, ArtistName  = "Kendrick Lamar", Description = "Compton"},
                new CatalogArtist { Id= 2, ArtistName  = "Young Thug", Description = "Trapper"},
                new CatalogArtist { Id= 3, ArtistName  = "Ludovico Einaudi", Description = "Test"},
                new CatalogArtist { Id= 4, ArtistName  = "Kamasi Washington", Description = "Test"},
            };
        }

        private IEnumerable<CatalogTrack> GetPreconfiguredCatalogTracks()
        {
            return new List<CatalogTrack>
            {
                new CatalogTrack { CatalogArtistId = 1, GenreId = 1 , AvailableStock = 100, Title = "DAMN." },
                new CatalogTrack { CatalogArtistId = 1, GenreId = 1 , AvailableStock = 100, Title = "Section.80" },
                new CatalogTrack { CatalogArtistId = 1, GenreId = 1 , AvailableStock = 100, Title = "good kid maad city" },
                //new CatalogTrack { CatalogTypeId = 1, CatalogBrandId = 2, AvailableStock = 100, Description = ".NET Black & White Mug", Name = ".NET Black & White Mug", Price= 8.50M, PictureFileName = "2.png" },
                //new CatalogTrack { CatalogTypeId = 2, CatalogBrandId = 5, AvailableStock = 100, Description = "Prism White T-Shirt", Name = "Prism White T-Shirt", Price = 12, PictureFileName = "3.png" },
                //new CatalogTrack { CatalogTypeId = 2, CatalogBrandId = 2, AvailableStock = 100, Description = ".NET Foundation T-shirt", Name = ".NET Foundation T-shirt", Price = 12, PictureFileName = "4.png" },
                //new CatalogTrack { CatalogTypeId = 3, CatalogBrandId = 5, AvailableStock = 100, Description = "Roslyn Red Sheet", Name = "Roslyn Red Sheet", Price = 8.5M, PictureFileName = "5.png" },
                //new CatalogTrack { CatalogTypeId = 2, CatalogBrandId = 2, AvailableStock = 100, Description = ".NET Blue Hoodie", Name = ".NET Blue Hoodie", Price = 12, PictureFileName = "6.png" },
                //new CatalogTrack { CatalogTypeId = 2, CatalogBrandId = 5, AvailableStock = 100, Description = "Roslyn Red T-Shirt", Name = "Roslyn Red T-Shirt", Price = 12, PictureFileName = "7.png" },
                //new CatalogTrack { CatalogTypeId = 2, CatalogBrandId = 5, AvailableStock = 100, Description = "Kudu Purple Hoodie", Name = "Kudu Purple Hoodie", Price = 8.5M, PictureFileName = "8.png" },
                //new CatalogTrack { CatalogTypeId = 1, CatalogBrandId = 5, AvailableStock = 100, Description = "Cup<T> White Mug", Name = "Cup<T> White Mug", Price = 12, PictureFileName = "9.png" },
                //new CatalogTrack { CatalogTypeId = 3, CatalogBrandId = 2, AvailableStock = 100, Description = ".NET Foundation Sheet", Name = ".NET Foundation Sheet", Price = 12, PictureFileName = "10.png" },
                //new CatalogTrack { CatalogTypeId = 3, CatalogBrandId = 2, AvailableStock = 100, Description = "Cup<T> Sheet", Name = "Cup<T> Sheet", Price = 8.5M, PictureFileName = "11.png" },
                //new CatalogTrack { CatalogTypeId = 2, CatalogBrandId = 5, AvailableStock = 100, Description = "Prism White TShirt", Name = "Prism White TShirt", Price = 12, PictureFileName = "12.png" },
            };
        }


    }
}
