namespace Store.API.Models
{
    public class StoreViynl
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CatalogArtistId { get; set; }
        public StoreArtist Artist { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public int AvailableStock { get; set; }
        public bool IsDisabled{get;set;} 
    }
}
