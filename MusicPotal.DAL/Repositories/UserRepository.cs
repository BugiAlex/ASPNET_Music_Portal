using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ASP_NET_HW2_MusicPortal.Interfaces;
using MusicPotal.DAL.EF;
using MusicPotal.DAL.Models;

namespace ASP_NET_HW2_MusicPortal.Repository
{
    public class UserRepository: IRepository<User>
    {
        private MusicPortalContext db;

        public UserRepository(MusicPortalContext context)
        {
            this.db = context;
        }
        public IEnumerable<User> GetAll()
        {
            return db.Users;
        }
        public User Get(int id)
        {
            return db.Users.Find(id);
        }
        public User Get(string name)
        {
            var users = db.Users.Where(a => a.Login == name);
            return users.FirstOrDefault();
        }
        public void Create(User item)
        {
            db.Users.Add(item);
        }
        public void Update(User item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            User user = db.Users.Find(id);
            if (user != null)
                db.Users.Remove(user);
        }      
        public void Dispose()
        {
            db.Dispose();
        }
    }
}