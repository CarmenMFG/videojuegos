using System;
using System.Collections.Generic;
using System.Text;
using Videogames.Repository.Entities;

namespace Videogames.Repository.Interfaces
{
    public interface IVideoGameRepository
    {
        public bool CreateVideoGameRepository(VideoGameEntity videGame, int idUser);
        public bool ModifyVideoGameRepository(VideoGameEntity videGame,int idUser);
        public bool DeactiveVideoGameRepository(int idVideGame, int idUser);
        public List<VideoGameEntity> GetAllVideoGameRepository(int idUser);
        public VideoGameEntity GetVideoGameRepository(int idVideoGame,int idUser);

        public List<SystemEntity> GetAllSystemsRepository();
        public List<SupportEntity> GetAllSupportsRepository();



    }
}
