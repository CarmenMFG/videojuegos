using System;
using System.Collections.Generic;
using System.Text;
using Videogames.Repository.Entities;

namespace Videogames.Repository.Interfaces
{
    public interface IVideoGameRepository
    {
        public bool CreateVideoGameRepository(VideoGameEntity videGame, int idUser);
        public bool ModifyVideoGameRepository(VideoGameEntity videGame, int idUser, string role);
        public bool DeactiveVideoGameRepository(int idVideGame, int idUser, string role);
        public List<VideoGameEntity> GetAllVideoGameRepository(int idUser, string role);
        public VideoGameEntity GetVideoGameRepository(int idVideoGame, int idUser, string role);

        public List<SystemEntity> GetAllSystemsRepository();
        public List<SupportEntity> GetAllSupportsRepository();



    }
}
