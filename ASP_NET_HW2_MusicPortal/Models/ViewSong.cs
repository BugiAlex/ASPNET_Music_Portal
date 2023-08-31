using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_NET_HW2_MusicPortal.Models
{
    public class ViewSong
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string User { get; set; }
        public string Singer { get; set; }
        public string Path { get; set; }
    }
}