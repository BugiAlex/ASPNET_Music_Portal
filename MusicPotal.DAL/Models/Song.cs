using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicPotal.DAL.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Singer { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Genre { get; set; }
        public string UserName { get; set; }
    }
}
