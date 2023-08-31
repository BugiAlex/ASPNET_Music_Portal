using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using MusicPotal.DAL.Models;

using MusicPotal.DAL.EF;

namespace ASP_NET_HW2_MusicPortal.Repository
{
    public class SongRepository: Interfaces.IRepository<Song>
    {
        private MusicPortalContext db;

        public SongRepository(MusicPortalContext context)
        {
            this.db = context;
        }
        public IEnumerable<Song> GetAll()
        {
            return db.Songs;
        }
        public Song Get(int id)
        {
            return db.Songs.Find(id);
        }
        public Song Get(string name)
        {
            var songs = db.Songs.Where(a => a.Name == name);
            return songs.FirstOrDefault();
        }
        public void Create(Song item)
        {
            db.Songs.Add(item);
        }
        public void Update(Song item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Song song = db.Songs.Find(id);
            if(song!=null)
            db.Songs.Remove(song);
        }      
        public void Dispose()
        {
            db.Dispose();
        }
    }
}