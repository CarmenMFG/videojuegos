using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
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

        public ResultDO CreateVideoGame(VideoGameDO videogame, int userId, string role) {
            
            ResultDO result = null;

            if (videogame != null)
            {
                // debemos comprobar el namesupport si no está vacio. 
                // en este caso debemos ir a por el a bbdd y obtener su id
                // si no existe, lo creamos
                if (role.ToUpper() == "ADMINISTRADOR" || role.ToUpper() == "USER")
                {
                     bool success = _repository.CreateVideoGameRepository(videogame.ConvertDOToEntity(),userId);

                    result = new ResultDO() { Success = success, Message = !success ? "Hay un problema en la creación del videojuego" : string.Empty };
                }
                else
                {
                    result = new ResultDO() { Success = false, Message = "No tiene permisos" };
                }
            }

            return result; 
       }
        public ResultDO ModifyVideoGame(VideoGameDO videogame, int userId, string role)
        {

            ResultDO result = null;

            if (videogame != null)
            {
                // debemos comprobar el namesupport si no está vacio. 
                // en este caso debemos ir a por el a bbdd y obtener su id
                // si no existe, lo creamos
                if (role.ToUpper() == "ADMINISTRADOR" || role.ToUpper() == "USER")
                {
                    bool success = _repository.ModifyVideoGameRepository(videogame.ConvertDOToEntity(), userId);

                    result = new ResultDO() { Success = success, Message = !success ? "Hay un problema en la creación del videojuego" : string.Empty };
                }
                else
                {
                    result = new ResultDO() { Success = false, Message = "No tiene permisos" };
                }
            }

            return result;
        }

        public object GetVideoGame(object idVideoGame, int v1, string v2)
        {
            throw new NotImplementedException();
        }

        public ResultDO DeactiveVideoGame(int idVideoGame, int userId, string role)
        {

            ResultDO result = null;

            if (idVideoGame != null)
            {
                if (role.ToUpper() == "ADMINISTRADOR" || role.ToUpper() == "USER")
                {
                   bool success = _repository.DeactiveVideoGameRepository(idVideoGame,userId);

                    result = new ResultDO() { Success = success, Message = !success ? "Hay un problema en la desactivación del videojuego" : string.Empty };
                }
                else
                {
                    result = new ResultDO() { Success = false, Message = "No tiene permisos" };
                }
            }

            return result;
        }
        public ResultDO GetAllVideoGame(int userId, string role)
        {

            ResultDO result = null;

                if (role.ToUpper() == "ADMINISTRADOR" || role.ToUpper() == "USER")
                {
                    var listVideoGamesEntity= _repository.GetAllVideoGameRepository(userId);
                    var listVideoGamesDO = new List<VideoGameDO>();
                    bool success = !(listVideoGamesEntity.Count==0);
                       foreach (VideoGameEntity vg in listVideoGamesEntity)
                            {
                                listVideoGamesDO.Add(vg.ConvertEntityToDO());
                            }
                    result = new ResultDO() { ListVideoGames = listVideoGamesDO,  Success = success, Message = !success ? "No tiene ningun videojuego activo" : string.Empty };
                }
                else
                {
                    result = new ResultDO() { Success = false, Message = "No tiene permisos" };
                }
           
           return result;
        }
        public ResultDO GetVideoGame(int idVideoGame,int userId, string role)
        {

            ResultDO result = null;

            if (role.ToUpper() == "ADMINISTRADOR" || role.ToUpper() == "USER")
            {
                var videoGamesEntity = _repository.GetVideoGameRepository(idVideoGame,userId);
                bool success = videoGamesEntity != null;
                result = new ResultDO() {CurrentVideoGame = videoGamesEntity.ConvertEntityToDO(), Success = success, Message = !success ? "No tiene ningun videojuego activo" : string.Empty };
            }
            else
            {
                result = new ResultDO() { Success = false, Message = "No tiene permisos" };
            }

            return result;
        }
    }
}
