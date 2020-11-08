using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Videogames.API.ViewModels
{
    public class SystemVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual string Platform { get; set; }//Nombre de plataforma
       
    }
}
