using System;
using System.Collections.Generic;
using System.Text;

namespace Videogames.Repository.Entities
{
   public class SupportEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<VideoGameEntity> VideoGames { get; set; }
    }
}
