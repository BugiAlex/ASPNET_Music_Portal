using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_NET_HW2_MusicPortal.Interfaces
{
    public interface IRepository<T> : IDisposable where T: class
    {
        IEnumerable<T> GetAll();      
        T Get(int id);
        T Get(string name);
        void Create(T item);       
        void Update(T item);
        void Delete(int id);
    }
}