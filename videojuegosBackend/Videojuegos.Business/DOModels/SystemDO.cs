using System;
using System.Collections.Generic;
using System.Text;

namespace Videogames.Business.DOModels
{
     public class SystemDO
    {
        public int Id { get; set; }
        public int IdPlatform { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public PlatformDO Platform { get; set; }
        public ICollection<VideoGameDO>  VideoGames{ get; set; }
    }
}
