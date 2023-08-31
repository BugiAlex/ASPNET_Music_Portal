using MusicPortal.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPortal.BLL.Interfaces
{
    public interface IUserService: IDisposable
    {
        void CreateUser(UserDTO teamDto);
        void UpdateUser(UserDTO teamDto);
        void DeleteUser(int id);
        UserDTO GetUser(int id);
        UserDTO GetUser(string login);
        IEnumerable<UserDTO> GetUsers();
    }
}
