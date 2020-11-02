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
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int CreatedUser { get; set; } 
        public virtual ICollection<VideoGameEntity> VideoGames { get; set; }
    }
}
