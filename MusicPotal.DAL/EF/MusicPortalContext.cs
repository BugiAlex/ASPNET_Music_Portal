using System.Data.Entity;
using MusicPotal.DAL.Models;

namespace MusicPotal.DAL.EF
{  
        public class MusicPortalContext : DbContext
        {
            
            public DbSet<User> Users { get; set; }
            public DbSet<Song> Songs { get; set; }
            public DbSet<Genre> Genres { get; set; }
        
        
        public MusicPortalContext(string connectionString)
           : base(connectionString)
            {
                
            }                 
        }
}
