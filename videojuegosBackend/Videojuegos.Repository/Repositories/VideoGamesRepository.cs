using System;
using Videogames.Repository.Data;
using Videogames.Repository.Entities;
using Videogames.Repository.Interfaces;


namespace Videojuegos.Repository.Repositories
{
    public class VideoGamesRepository : IVideoGameRepository
    {
        private VideogameContext _context;
        public VideoGamesRepository(VideogameContext context)
        {
            _context = context;
        }

        public bool CreateVideoGameRepository(VideoGameEntity videoGame)
        {
            try
            {
                _context.VideoGames.Add(videoGame);

                _context.SaveChanges();

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
