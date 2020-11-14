using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Videogames.Repository.Data;
using Videogames.Repository.Entities;
using Videogames.Repository.Interfaces;

namespace Videogames.Repository.Repositories
{
    public class VideoGamesRepository : IVideoGameRepository
    {
        private VideogameContext _context;
        public VideoGamesRepository(VideogameContext context)
        {
            _context = context;
        }

        public bool CreateVideoGameRepository(VideoGameEntity videoGame,int userId)
        {
            try
            {
               videoGame.CreateDate = DateTime.Now;
               videoGame.UpdateDate = DateTime.Now;
               videoGame.IdUser = userId;
               videoGame.IsActive = true;
               _context.VideoGames.Add(videoGame);
               _context.SaveChanges();

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool DeactiveVideoGameRepository(int idVideoGame,int idUser)
        {
            try
            {
                VideoGameEntity videoGameDeactived = _context.VideoGames.FirstOrDefault(vg => vg.Id == idVideoGame);
                if (videoGameDeactived!=null && videoGameDeactived.IdUser == idUser)
                {
                    videoGameDeactived.IsActive = false;
                    videoGameDeactived.UpdateDate = DateTime.Now;
                   _context.SaveChanges();
                   
                    return true;

                }
                            
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ModifyVideoGameRepository(VideoGameEntity videoGame,int idUser)
        {  
            try
            {
                //solo saca el videojuego con ese id y q sea activo
                VideoGameEntity videoGameModified = _context.VideoGames.Where(v => v.IsActive).FirstOrDefault(vg => vg.Id == videoGame.Id);
                if (videoGameModified != null && videoGameModified.IdUser == idUser)
                {
                    videoGameModified.Genre = videoGame.Genre;
                    videoGameModified.BackCover = videoGame.BackCover;
                    videoGameModified.BarCode = videoGame.BarCode;
                    videoGameModified.CoverPage = videoGame.CoverPage;
                    videoGameModified.Description = videoGame.Description;
                    videoGameModified.Developer = videoGame.Developer;
                    videoGameModified.Distributor = videoGame.Distributor;
                    videoGameModified.IdSystem = videoGame.IdSystem;
                    videoGameModified.IdSupport = videoGame.IdSupport;
                    videoGameModified.IsActive = videoGame.IsActive;
                    videoGameModified.Language = videoGame.Language;
                    videoGameModified.Notes = videoGame.Notes;
                    videoGameModified.Redump = videoGame.Redump;
                    videoGameModified.Region = videoGame.Region;
                    videoGameModified.UpdateDate = DateTime.Now;
                    videoGameModified.Title = videoGame.Title;
                    videoGameModified.IsActive = true;
                    videoGameModified.IsActive = true;
                    videoGameModified.ReleaseDate = videoGame.ReleaseDate;
                     _context.SaveChanges();
                  
                    return true;

                    }

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        
        public List<VideoGameEntity> GetAllVideoGameRepository(int idUser)
        {
           //solo muestra los videojuegos del usuario q están activos  
            List<VideoGameEntity> videoGameList = _context.VideoGames.Where(v => v.IdUser == idUser && v.IsActive).ToList();
            return videoGameList;
        }
        
        public VideoGameEntity GetVideoGameRepository(int idVideoGame, int idUser)
        {
            //solo muestra els videojuegos del usuario q están activos  
            VideoGameEntity videoGameCurrent = _context.VideoGames
                                                .Include(v=>v.Support)
                                                .Include(v => v.System)
                                                .Include(v=>v.System.Platform)
                                                .Where(v => v.IdUser == idUser && v.IsActive)
                                                .FirstOrDefault(vg => vg.Id == idVideoGame);
            return videoGameCurrent;
        }

        public List<SystemEntity> GetAllSystemsRepository()
        {
            List<SystemEntity> listSystems = _context.Systems.Include(c=>c.Platform).ToList();
            return listSystems;
        }

        public List<SupportEntity> GetAllSupportsRepository()
        {
            List<SupportEntity> listSupports = _context.Supports.ToList();
            return listSupports;

        }

       


    }
}
