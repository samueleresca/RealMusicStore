namespace Store.API.Responses
{
    public class StoreVinylListResponseModel
    {
        public string Title { get; set; }
        public int? ArtistId { get; set; }
        public int? GenreId { get; set; }
        public int AvailableStock { get; set; }
        public bool IsDisabled { get; set; }
    }
}
