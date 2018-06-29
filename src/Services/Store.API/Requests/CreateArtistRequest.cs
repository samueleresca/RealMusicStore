namespace Store.API.Requests
{
    public class CreateArtistRequest
    {
        public string ArtistName { get; set; }
        public string Description { get; set; }
        public bool IsDisabled { get; set; }
    }
}
