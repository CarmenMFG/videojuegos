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
        public string Password { get; set; }
        public int IdRol { get; set; }
        public RolEntity Rol { get; set; }
        public virtual ICollection<VideoGameEntity> VideoGames { get; set; }
    }
}
