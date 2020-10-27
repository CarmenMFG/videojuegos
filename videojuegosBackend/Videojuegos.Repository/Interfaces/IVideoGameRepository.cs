using System;
using System.Collections.Generic;
using System.Text;
using Videogames.Repository.Entities;

namespace Videogames.Repository.Interfaces
{
    public interface IVideoGameRepository
    {
        public bool CreateVideoGameRepository(VideoGameEntity videGame);
    }
}
