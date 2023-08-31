using ASP_NET_HW2_MusicPortal.Interfaces;
using MusicPotal.DAL.EF;
using MusicPotal.DAL.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace ASP_NET_HW2_MusicPortal.Repository
{
    public class GenreRepository: IRepository<Genre>
    {
        private MusicPortalContext db;

        public GenreRepository(MusicPortalContext context)
        {
            this.db = context;
        }
        public IEnumerable<Genre> GetAll()
        {
            return db.Genres;
        }
        public Genre Get(int id)
        {
            return db.Genres.Find(id);
        }
        public Genre Get(string name)
        {
            var genres = db.Genres.Where(a => a.Name == name);
            return genres.FirstOrDefault();
        }
        public void Create(Genre item)
        {
            db.Genres.Add(item);
        }
        public void Update(Genre item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Genre item = db.Genres.Find(id);
            if(item!=null)
            db.Genres.Remove(item);
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}