using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicPotal.DAL.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
        public virtual ICollection<Song> Songs { get; set; }
    }
}
