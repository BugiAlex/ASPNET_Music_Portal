using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicPotal.DAL.Models
{
    public class Genre
    {
        public int Id { get; set; }    
        public string Name { get; set; }
        public virtual ICollection<Song> Songs { get; set; }
    }
}
