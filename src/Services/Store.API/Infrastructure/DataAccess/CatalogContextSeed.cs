using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Store.API.Models;

namespace Store.API.Infrastructure.DataAccess
{
    public class CatalogContextSeed
    {
        public async Task SeedAsync(StoreContext context, IHostingEnvironment env, ILogger<CatalogContextSeed> logger)
        {

            if (!context.Genres.Any())
            {
                await context.Genres.AddRangeAsync(GetPreconfiguredCatalogGenres());
                await context.SaveChangesAsync();
            }

            if (!context.StoreArtists.Any())
            {
                await context.StoreArtists.AddRangeAsync(GetPreconfiguredCatalogArtists());
                await context.SaveChangesAsync();
            }

            if (!context.StoreTracks.Any())
            {
                await context.StoreTracks.AddRangeAsync(GetPreconfiguredCatalogTracks());
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


        IEnumerable<StoreArtist> GetPreconfiguredCatalogArtists()
        {
            return new List<StoreArtist>
            {
                new StoreArtist {  Id= 1, ArtistName  = "Kendrick Lamar", Description = "Compton"},
                new StoreArtist { Id= 2, ArtistName  = "Young Thug", Description = "Trapper"},
                new StoreArtist { Id= 3, ArtistName  = "Ludovico Einaudi", Description = "Test"},
                new StoreArtist { Id= 4, ArtistName  = "Kamasi Washington", Description = "Test"},
            };
        }

        IEnumerable<StoreViynl> GetPreconfiguredCatalogTracks()
        {
            return new List<StoreViynl>
            {
                new StoreViynl { ArtistId = 1, GenreId = 1 , AvailableStock = 100, Title = "DAMN." },
                new StoreViynl { ArtistId = 1, GenreId = 1 , AvailableStock = 100, Title = "Section.80" },
                new StoreViynl { ArtistId = 1, GenreId = 1 , AvailableStock = 100, Title = "good kid maad city" },
                new StoreViynl { ArtistId = 3, GenreId = 3 , AvailableStock = 100, Title = "Nuvole bianche" },
            };
        }


    }
}
