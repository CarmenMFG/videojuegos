using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Videogames.Repository.Entities;

namespace Videogames.API.ViewModels
{
    public class UserVM
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string User { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public int IdRol { get; set; }
        public string Rol { get; set; }
       // public string VideoGames { get; set; }

      
    }
}
