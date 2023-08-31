using MusicPortal.BLL.DTO;
using MusicPortal.BLL.Interfaces;
using System.Collections.Generic;
using MusicPortal.BLL.Infrastructure;
using MusicPotal.DAL.Interfaces;
using MusicPotal.DAL.Models;

namespace MusicPortal.BLL.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork db { get; set; }
        public UserService(IUnitOfWork uow)
        {
            this.db = uow;
        }
        public void CreateUser(UserDTO userDto)
        {
            User newUser = new User
            {
                Id = userDto.Id,
                Name = userDto.Name,
                Password = userDto.Password,
                Login = userDto.Login,
                Role = userDto.Role,
                Status = userDto.Status,
                Salt = userDto.Salt
            };
            db.Users.Create(newUser);
            db.Save();
        }
        public void UpdateUser(UserDTO userDto)
        {
            User userUpdate = db.Users.Get(userDto.Id);
            userUpdate.Role = userDto.Role;
            userUpdate.Status = userDto.Status;
            db.Users.Update(userUpdate);
            db.Save();
        }
        public void DeleteUser(int id)
        {
            db.Users.Delete(id);
            db.Save();
        }
        public UserDTO GetUser(int id)
        {
            var user = db.Users.Get(id);
            if (user == null)
                throw new ValidationException("Wrong user!", "");
            return new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Password = user.Password,
                Role = user.Role,
                Status = user.Status,
                Login = user.Login,
                Salt = user.Salt
            };
        }
        public UserDTO GetUser(string login)
        {
            var user = db.Users.Get(login);
            if (user == null)
                throw new ValidationException("Wrong user!", "");
            return new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Password = user.Password,
                Role = user.Role,
                Status = user.Status,
                Login = user.Login,
                Salt = user.Salt
            };
        }
        public IEnumerable<UserDTO> GetUsers()
        {
            List<UserDTO> usersDTO = new List<UserDTO>();
            var users = db.Users.GetAll();
            foreach (var i in users)
            {
                UserDTO newUserDTO = new UserDTO
                {
                    Id = i.Id,
                    Name = i.Name,
                    Password = i.Password,
                    Role = i.Role,
                    Status = i.Status,
                    Login = i.Login,
                    Salt = i.Salt

                };
                usersDTO.Add(newUserDTO);
            }
            return usersDTO;
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}