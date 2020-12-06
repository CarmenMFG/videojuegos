using System;
using System.Collections.Generic;
using System.Text;

namespace Videogames.Repository.Entities
{
   public  class UserEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string User { get; set; }
        public int IdRol { get; set; }
        public byte[] PasswordHash { get; set;}
        public byte[] PasswordSalt { get; set; }
        public RolEntity Rol { get; set; }
        public ICollection<VideoGameEntity> VideoGames { get; set; }
        public bool IsActive { get; set; }
    }
}
