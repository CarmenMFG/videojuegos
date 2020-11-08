using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Videogames.API.ViewModels;

namespace Videogames.API.Interface
{
   public interface ITokenService
    {
        public string CreateToken(UserVM user);
    }
}
