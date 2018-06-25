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
        public bool IsDeleted{get;set;} 
    }
}
