using System;
using Videogames.Business.DOModels;
using Videogames.Business.Extensions;
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
                    var newVideoGame = videogame.ConvertDOToEntity();
                    newVideoGame.CreateDate = DateTime.Now;
                    newVideoGame.UpdateDate = DateTime.Now;
                    newVideoGame.IdUser = userId;

                    bool success = _repository.CreateVideoGameRepository(newVideoGame);

                    result = new ResultDO() { Success = success, Message = !success ? "Hay un problema en la creación del videojuego" : string.Empty };
                }
                else
                {
                    result = new ResultDO() { Success = false, Message = "No tiene permisos" };
                }
            }

            return result; 
       }
    }
}
