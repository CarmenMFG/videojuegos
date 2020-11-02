using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Videogames.API.ViewModels
{
    public class SystemVM
    {
        public int Id { get; set; }
        public int IdPlatform { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual string Platforms { get; set; }
        public virtual string VideoGames { get; set; }
    }
}
