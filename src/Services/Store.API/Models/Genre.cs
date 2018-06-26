namespace Store.API.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public bool IsDisabled { get; set; }
    }
}