using System;
using System.Collections.Generic;
using System.Text;

namespace Videogames.Repository.Entities
{
    public class PlatformEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<SystemEntity> Systems { get; set; }
    }
}
