using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPortal.BLL.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required(ErrorMessage = "The field must be set.")]
        public string Login { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }      
    }
}
