using System;
using System.Collections.Generic;
using System.Linq;
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
                if (videoGameDeactived.IdUser == idUser)
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
                if (videoGameModified.IdUser == idUser)
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
                        videoGameModified.ReleaseDate = videoGame.ReleaseDate;
                        videoGameModified.UpdateDate = DateTime.Now;
                        videoGameModified.Title = videoGame.Title;
                        videoGameModified.IsActive = true;

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
            //solo muestra los videojuegos del usuario q están activos  
            VideoGameEntity videoGameCurrent = _context.VideoGames
                                                .Where(v => v.IdUser == idUser && v.IsActive)
                                                .FirstOrDefault(vg => vg.Id == idVideoGame);
            return videoGameCurrent;
        }
       /* public SupportEntity GetSupportRepository(string name, int idUser)
        {
            SupportEntity supportCurrent = _context.Supports
                                            .Where(sup => sup.Name.ToUpper() == name.ToUpper()
                                            && (sup.CreatedUser==idUser))
                                            .FirstOrDefault();
            return supportCurrent;
        }

        public int AddSupportRepository(string name,int idUser)
        {
            try
            {
                var supportCurrent = new SupportEntity();
                supportCurrent.CreateDate = DateTime.Now;
                supportCurrent.UpdateDate = DateTime.Now;
                supportCurrent.CreatedUser = idUser;
                supportCurrent.Name = name;
                _context.Supports.Add(supportCurrent);
                _context.SaveChanges();

                return supportCurrent.Id;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }*/

    
    }
}
