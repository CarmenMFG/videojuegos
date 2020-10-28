﻿
using Videogames.Business.DOModels;
using Videojuegos.API.ViewModels;

namespace Videogames.API.Extensions
{
    public static class VideoGameVMExtension
    {
        public static VideoGameDO ConvertVMToDO(this VideoGameVM modelVM)
        {
            var modelDO = new VideoGameDO
            {
                Id = modelVM.Id,
                BackCover = modelVM.BackCover,
                BarCode = modelVM.BarCode,
                CoverPage = modelVM.CoverPage,
               // CreateDate = modelVM.CreateDate,
                Description = modelVM.Description,
                Developer = modelVM.Developer,
                Distributor = modelVM.Distributor,
                Genre = modelVM.Genre,
                IdPlatform = modelVM.IdPlatform,
                IdSupport = modelVM.IdSupport,
               // IdUser = modelVM.IdUser,
                IsActive = modelVM.IsActive,
                Language = modelVM.Language,
                Notes = modelVM.Notes,
               // Platform = modelVM.Platform,
                Redump = modelVM.Redump,
                Region = modelVM.Region,
                ReleaseDate = modelVM.ReleaseDate,
              //  Support = modelVM.Support,
                Title = modelVM.Title
            };
          //  modelDO.UpdateDate = modelVM.UpdateDate;
          //  modelDO.User = modelVM.User;
            

            return modelDO;

        }
        public static VideoGameVM ConvertDOToVM(this VideoGameDO modelDO )
        {
            var modelVM = new VideoGameVM
            {
                Id = modelDO.Id,
                BackCover = modelDO.BackCover,
                BarCode = modelDO.BarCode,
                CoverPage = modelDO.CoverPage,
              //  CreateDate = modelDO.CreateDate,
                Description = modelDO.Description,
                Developer = modelDO.Developer,
                Distributor = modelDO.Distributor,
                Genre = modelDO.Genre,
                IdPlatform = modelDO.IdPlatform,
                IdSupport = modelDO.IdSupport,
               // IdUser = modelDO.IdUser,
                IsActive = modelDO.IsActive,
                Language = modelDO.Language,
                Notes = modelDO.Notes,
              //  Platform = modelDO.Platform,
                Redump = modelDO.Redump,
                Region = modelDO.Region,
                ReleaseDate = modelDO.ReleaseDate,
              //  Support = modelDO.Support,
                Title = modelDO.Title,
              //  UpdateDate = modelDO.UpdateDate,
              //  User = modelDO.User
            };

            return modelVM;

        }
    }

    }