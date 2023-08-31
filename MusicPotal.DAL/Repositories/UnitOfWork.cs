using ASP_NET_HW2_MusicPortal.Interfaces;
using ASP_NET_HW2_MusicPortal.Repository;
using MusicPotal.DAL.EF;
using MusicPotal.DAL.Interfaces;
using MusicPotal.DAL.Models;
using System;

namespace MusicPotal.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private MusicPortalContext db;
        private UserRepository userRepository;
        private SongRepository songRepository;
        private GenreRepository genreRepository;

        public UnitOfWork(string connectionString)
        {
            db = new MusicPortalContext(connectionString);
            
        }
      
        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }

        public IRepository<Song> Songs
        {
            get
            {
                if (songRepository == null)
                    songRepository = new SongRepository(db);
                return songRepository;
            }
        }

        public IRepository<Genre> Genres
        {
            get
            {
                if (genreRepository == null)
                    genreRepository = new GenreRepository(db);
                return genreRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db?.Dispose();
                    songRepository?.Dispose();
                    genreRepository?.Dispose();
                    userRepository?.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
