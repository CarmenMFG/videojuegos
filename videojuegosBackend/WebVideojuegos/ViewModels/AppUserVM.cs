using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Videogames.API.ViewModels
{
    public class AppUserVM
    {
        [Required]
        public string User { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password{ get; set; }
    }
}
