using System.Collections;
using System.Collections.Generic;

namespace Store.API.Models
{
    public class StoreArtist
    {
        public int  Id { get; set; }
        public string ArtistName { get; set; }
        public string Description { get; set; }
        public bool IsDisabled { get; set; }
        public virtual ICollection<StoreViynl> Vinyls { get; set; }
    }
}
