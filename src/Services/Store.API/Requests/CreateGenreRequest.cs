namespace Store.API.Requests
{
    public class CreateGenreRequest
    {
        public string Description { get; set; }
        public string Title { get; set; }
        public bool IsDisabled { get; set; }
    }
}
