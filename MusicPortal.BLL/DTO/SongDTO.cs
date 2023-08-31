using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPortal.BLL.DTO
{
    public class SongDTO
    {
        public int Id { get; set; }
        public string Singer { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Genre { get; set; }
        public string UserName { get; set; }
    }
}
