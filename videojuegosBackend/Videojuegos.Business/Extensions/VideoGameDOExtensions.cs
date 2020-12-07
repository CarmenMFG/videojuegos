
using System.Collections.Generic;
using Videogames.Business.DOModels;
using Videogames.Repository.Entities;

namespace Videogames.Business.Extensions
{
    public static class VideoGameDOExtension
    {
        public static VideoGameEntity ConvertDOToEntity(this VideoGameDO modelDO)
        {
            VideoGameEntity modelEntity = null;
            if (modelDO != null)
            {
                modelEntity = new VideoGameEntity()
                {
                    Id = modelDO.Id,
                    BackCover = modelDO.BackCover,
                    BarCode = modelDO.BarCode,
                    CoverPage = modelDO.CoverPage,
                    Description = modelDO.Description,
                    Developer = modelDO.Developer,
                    Distributor = modelDO.Distributor,
                    Genre = modelDO.Genre,
                    IdSystem = modelDO.IdSystem,
                    IdSupport = modelDO.IdSupport,
                    IsActive = modelDO.IsActive,
                    Language = modelDO.Language,
                    Notes = modelDO.Notes,
                    Redump = modelDO.Redump,
                    Region = modelDO.Region,
                    ReleaseDate = modelDO.ReleaseDate,
                    Title = modelDO.Title
                };
              

            }
            return modelEntity;

        }
        public static VideoGameDO ConvertEntityToDO(this VideoGameEntity modelEntity )
        {
            VideoGameDO modelVM = null;
            if (modelEntity != null)
            {
                modelVM = new VideoGameDO
                {
                    Id = modelEntity.Id,
                    BackCover = modelEntity.BackCover,
                    BarCode = modelEntity.BarCode ?? string.Empty,
                    CoverPage = modelEntity.CoverPage,
                    Description = modelEntity.Description?? string.Empty,
                    Developer = modelEntity.Developer ?? string.Empty,
                    Distributor = modelEntity.Distributor ?? string.Empty,
                    Genre = modelEntity.Genre ?? string.Empty,
                    IdSystem = modelEntity.IdSystem,
                    IdSupport = modelEntity.IdSupport,
                    IsActive = modelEntity.IsActive,
                    Language = modelEntity.Language ?? string.Empty,
                    Notes = modelEntity.Notes ?? string.Empty,
                    Redump = modelEntity.Redump ?? string.Empty,
                    Region = modelEntity.Region ?? string.Empty,
                    ReleaseDate = modelEntity.ReleaseDate,
                    Title = modelEntity.Title ?? string.Empty,
                 };
            }
            if (modelEntity.Support != null)
            {
                modelVM.Support = new SupportDO
                {
                    Description = modelEntity.Support.Description,
                    Name = modelEntity.Support.Name,
                    Id = modelEntity.Support.Id
                };
            }
            if (modelEntity.System != null)
            {

                modelVM.System = new SystemDO
                {
                    Description = modelEntity.System.Description,
                    Name = modelEntity.System.Name,
                    Id = modelEntity.System.Id
                
                };
                if (modelEntity.System.Platform!=null)
                {
                 modelVM.Platform= new PlatformDO
                 {
                     Description = modelEntity.System.Platform.Description,
                     Name = modelEntity.System.Platform.Name,
                     Id = modelEntity.System.Platform.Id

                 };
                }
            }
           

            return modelVM;
        }

        public static List<VideoGameDO> ConvertEntitiesToDOs(this List<VideoGameEntity> modelEntities)
        {
            List<VideoGameDO> listVideoGameDO = null;
            if (modelEntities != null)
            {
                listVideoGameDO = new List<VideoGameDO>();

                foreach (VideoGameEntity vi in modelEntities)
                {
                    var model = vi.ConvertEntityToDO();
                    listVideoGameDO.Add(model);
                }

            }
          return listVideoGameDO;
        }
    }

    }
