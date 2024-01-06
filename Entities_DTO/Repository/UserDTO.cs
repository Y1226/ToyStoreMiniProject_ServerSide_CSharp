using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_DTO.Repository
{
    public class UserDTO
    {
        public string? UserId { get; set; }

        public string? UserFirstName { get; set; }

        public string? UserLastName { get; set; }

        public string? UserAddress { get; set; }

        public string? UserEmail { get; set; }

        public string? UserPhone { get; set; }

        public string? UserPassword { get; set;}
    }
}
