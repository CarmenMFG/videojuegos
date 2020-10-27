using System;
using Videogames.Business.DOModels;
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

        public bool CreateVideoGame(VideoGameDO videogame) {

            //_repository.CreateVideoGameRepository()
            return true; 
       }
    }
}
