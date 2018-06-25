using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Model
{
    public class CatalogTrack
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CatalogArtistId { get; set; }
        public CatalogArtist Artist { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public int AvailableStock { get; set; }
    }
}
