﻿
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
                    // CreateDate = modelVM.CreateDate,
                    Description = modelDO.Description,
                    Developer = modelDO.Developer,
                    Distributor = modelDO.Distributor,
                    Genre = modelDO.Genre,
                    IdSystem = modelDO.IdSystem,
                    IdSupport = modelDO.IdSupport,
                    // IdUser = modelVM.IdUser,
                    IsActive = modelDO.IsActive,
                    Language = modelDO.Language,
                    Notes = modelDO.Notes,
                    // Platform = modelVM.Platform,
                    Redump = modelDO.Redump,
                    Region = modelDO.Region,
                    ReleaseDate = modelDO.ReleaseDate,
                    //  Support = modelVM.Support,
                    Title = modelDO.Title
                };
                //  modelDO.UpdateDate = modelVM.UpdateDate;
                //  modelDO.User = modelVM.User;

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
                    BarCode = modelEntity.BarCode,
                    CoverPage = modelEntity.CoverPage,
                    //  CreateDate = modelDO.CreateDate,
                    Description = modelEntity.Description,
                    Developer = modelEntity.Developer,
                    Distributor = modelEntity.Distributor,
                    Genre = modelEntity.Genre,
                    IdSystem = modelEntity.IdSystem,
                    IdSupport = modelEntity.IdSupport,
                    // IdUser = modelDO.IdUser,
                    IsActive = modelEntity.IsActive,
                    Language = modelEntity.Language,
                    Notes = modelEntity.Notes,
                    //  Platform = modelDO.Platform,
                    Redump = modelEntity.Redump,
                    Region = modelEntity.Region,
                    ReleaseDate = modelEntity.ReleaseDate,
                    //  Support = modelDO.Support,
                    Title = modelEntity.Title,
                    //  UpdateDate = modelDO.UpdateDate,
                    //  User = modelDO.User
                };
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
