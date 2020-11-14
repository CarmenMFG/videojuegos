using System;
using System.Collections.Generic;
using Videogames.Business.DOModels;
using Videogames.Business.Extensions;
using Videogames.Repository.Entities;
using Videogames.Repository.Interfaces;

namespace Videogames.Business
{
    public class BusinessManagment
    {
        private readonly IVideoGameRepository _repository;


        public BusinessManagment(IVideoGameRepository repository)
        {
            _repository = repository;
        }

        public bool CreateVideoGame(VideoGameDO videogame, int userId, string role) {
           
            bool success = false;

            if (videogame != null)
            {
               
                if (role.ToUpper() == "ADMINISTRADOR" || role.ToUpper() == "USER")
                {
                    success = _repository.CreateVideoGameRepository(videogame.ConvertDOToEntity(),userId);

                 }
                
            }

            return success; 
       }

        public bool ModifyVideoGame(VideoGameDO videogame, int userId, string role)
        {

            bool success = false;

            if (videogame != null)
            {
                
                if (role.ToUpper() == "ADMINISTRADOR" || role.ToUpper() == "USER")
                {
                   success = _repository.ModifyVideoGameRepository(videogame.ConvertDOToEntity(), userId);

                }
            }

            return success;
        }

       
        public bool DeactiveVideoGame(int idVideoGame, int userId, string role)
        {

            bool success = false;

              if (role.ToUpper() == "ADMINISTRADOR" || role.ToUpper() == "USER")
                {
                    success = _repository.DeactiveVideoGameRepository(idVideoGame,userId);

                }
           return success;
        }

        public List<VideoGameDO> GetAllVideoGame(int userId, string role)
        {

            List<VideoGameDO> listVideoGamesDO = null;

                if (role.ToUpper() == "ADMINISTRADOR" || role.ToUpper() == "USER")
                {
                     List<VideoGameEntity> lista = _repository.GetAllVideoGameRepository(userId);
                    listVideoGamesDO =lista.ConvertEntitiesToDOs();
                                 
                }
           
           return listVideoGamesDO;
        }

        public VideoGameDO GetVideoGame(int idVideoGame,int userId, string role)
        {
            
            VideoGameDO videoGamesDO = null;
            
            if (role.ToUpper() == "ADMINISTRADOR" || role.ToUpper() == "USER")
            {
                videoGamesDO = _repository.GetVideoGameRepository(idVideoGame, userId).ConvertEntityToDO();
            }
           
            return videoGamesDO;
          
        }

        public List<SystemDO> GetAllSystems(int userId, string role)
        {
           
            List<SystemDO> listSystemsDO = null;

            if (role.ToUpper() == "ADMINISTRADOR" || role.ToUpper() == "USER")
            {
                 listSystemsDO = _repository.GetAllSystemsRepository().ConvertEntitiesToDOs();
             }
          
            return listSystemsDO;
        }

        public List<SupportDO> GetAllSupports(int userId,string role)
        {
            List<SupportEntity> listSup = null;
            List<SupportDO> listSupportDO = null;

            if (role.ToUpper() == "ADMINISTRADOR" || role.ToUpper() == "USER")
            {
                listSup = _repository.GetAllSupportsRepository();
                listSupportDO=listSup.ConvertEntitiesToDOs();
                //listSupportDO = _repository.GetAllSupportsRepository().ConvertEntitiesToDOs();

            }
         
            return listSupportDO;

        }
      
    }
}
