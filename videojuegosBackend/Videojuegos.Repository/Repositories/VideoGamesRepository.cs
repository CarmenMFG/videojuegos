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
            if (videoGame != null && videoGame.Title != String.Empty && videoGame.CoverPage != null)
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
                catch (Exception ex)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }    
        }

        public bool DeactiveVideoGameRepository(int idVideoGame,int idUser,string role)
        {
            try
            {
                VideoGameEntity videoGameDeactived = _context.VideoGames.FirstOrDefault(vg => vg.Id == idVideoGame);
                if (videoGameDeactived!=null && (videoGameDeactived.IdUser == idUser || role.ToUpper() == "ADMIN"))
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

        public bool ModifyVideoGameRepository(VideoGameEntity videoGame,int idUser,string role)
        {  
            try
            {
                //solo saca el videojuego con ese id y q sea activo
                VideoGameEntity videoGameModified = _context.VideoGames.Where(v => v.IsActive).FirstOrDefault(vg => vg.Id == videoGame.Id);
                if (videoGameModified != null && (videoGameModified.IdUser == idUser || role.ToUpper() == "ADMIN")
                    &&  videoGameModified.Title != String.Empty  && videoGameModified.CoverPage != null)
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
        
        public List<VideoGameEntity> GetAllVideoGameRepository(int idUser,string role)
        {
            List<VideoGameEntity> videoGameList;
            if (role.ToUpper() == "USER")
            {
                //solo muestra los videojuegos del usuario q están activos o todos los activos si es administrador 
               videoGameList = _context.VideoGames
                                                    .Include(v => v.Support)
                                                    .Include(v => v.System)
                                                    .Include(v => v.System.Platform)
                                                    .Where(v => v.IsActive && v.IdUser == idUser).OrderBy(v => v.Title).ToList();

            }
            else
            {
                videoGameList = _context.VideoGames
                                                   .Include(v => v.Support)
                                                   .Include(v => v.System)
                                                   .Include(v => v.System.Platform)
                                                   .OrderBy(v => v.Title)
                                                   .Where(v => v.IsActive).OrderBy(v => v.Title).ToList();

            }


            return videoGameList;
        }
        
        public VideoGameEntity GetVideoGameRepository(int idVideoGame, int idUser ,string role)
        {
            VideoGameEntity videoGameCurrent = null;
            if (role.ToUpper() == "USER")
            {

                //solo muestra els videojuegos del usuario q están activos  
                videoGameCurrent = _context.VideoGames
                                                .Include(v => v.Support)
                                                .Include(v => v.System)
                                                .Include(v => v.System.Platform)
                                                .Where(v => v.IdUser == idUser && v.IsActive)
                                                .FirstOrDefault(vg => vg.Id == idVideoGame);
            }
            else
            {
                videoGameCurrent = _context.VideoGames
                                              .Include(v => v.Support)
                                              .Include(v => v.System)
                                              .Include(v => v.System.Platform)
                                              .Where(v=>v.IsActive)
                                              .FirstOrDefault(vg => vg.Id == idVideoGame);

            }
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
