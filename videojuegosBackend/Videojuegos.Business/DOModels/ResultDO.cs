using System;
using System.Collections.Generic;
using System.Text;

namespace Videogames.Business.DOModels
{
    public class ResultDO
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public VideoGameDO CurrentVideoGame { get; set; }

        public List<VideoGameDO> ListVideoGames{get;set;}

        public SystemDO CurrentSystem { get; set; }

        public List<SystemDO> ListSystems { get; set; }
        public PlatformDO CurrentPlatform { get; set; }

        public List<PlatformDO> ListPlatform { get; set; }

    }
}
