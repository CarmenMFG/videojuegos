using System;
using System.Collections.Generic;
using System.Text;

namespace Videogames.Repository.Entities
{
    public class SystemEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int IdPlatform { get; set; }
        public PlatformEntity Platform { get; set; }
        public ICollection<VideoGameEntity> VideoGames { get; set; }
    }
}
