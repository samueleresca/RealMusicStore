using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.API.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

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

        IEnumerable<Genre> GetPreconfiguredCatalogGenres()
        {
            return new List<Genre>()
            {
                new Genre { Id= 1, Title = "Hip/Hop", Description = ""},
                new Genre  {Id= 2,Title = "Rap", Description = ""},
                new Genre  {Id = 3, Title = "Classic", Description = ""},
                new Genre  {Id = 4, Title = "Jazz", Description = ""}
            };
        }


        IEnumerable<CatalogArtist> GetPreconfiguredCatalogArtists()
        {
            return new List<CatalogArtist>
            {
                new CatalogArtist {  Id= 1, ArtistName  = "Kendrick Lamar", Description = "Compton"},
                new CatalogArtist { Id= 2, ArtistName  = "Young Thug", Description = "Trapper"},
                new CatalogArtist { Id= 3, ArtistName  = "Ludovico Einaudi", Description = "Test"},
                new CatalogArtist { Id= 4, ArtistName  = "Kamasi Washington", Description = "Test"},
            };
        }

        IEnumerable<CatalogTrack> GetPreconfiguredCatalogTracks()
        {
            return new List<CatalogTrack>
            {
                new CatalogTrack { CatalogArtistId = 1, GenreId = 1 , AvailableStock = 100, Title = "DAMN." },
                new CatalogTrack { CatalogArtistId = 1, GenreId = 1 , AvailableStock = 100, Title = "Section.80" },
                new CatalogTrack { CatalogArtistId = 1, GenreId = 1 , AvailableStock = 100, Title = "good kid maad city" },
                new CatalogTrack { CatalogArtistId = 3, GenreId = 3 , AvailableStock = 100, Title = "Nuvole bianche" },
            };
        }


    }
}
