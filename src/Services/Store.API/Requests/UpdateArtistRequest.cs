namespace Store.API.Requests
{
    public class UpdateArtistRequest
    {
        public int Id { get; set; }
        public string ArtistName { get; set; }
        public string Description { get; set; }
        public bool IsDisabled { get; set; }
    }
}
