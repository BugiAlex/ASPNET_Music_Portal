using ASP_NET_HW2_MusicPortal.Interfaces;
using MusicPotal.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPotal.DAL.Interfaces
{
   public interface IUnitOfWork : IDisposable
    {
        IRepository<Genre> Genres { get; }
        IRepository<User> Users { get; }
        IRepository<Song> Songs { get; }
        void Save();
    }
}
