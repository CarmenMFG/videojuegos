
using Videogames.Business.DOModels;
using Videojuegos.API.ViewModels;

namespace Videogames.API.Extensions
{
    public static class VideoGameVMExtension
    {
        public static VideoGameDO ConvertVMToDO(this VideoGameVM modelVM)
        {
            VideoGameDO modelDO = null;
            if (modelVM != null)
            {
                modelDO = new VideoGameDO
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
                    IdSystem = modelVM.IdSystem,
                    IdSupport = modelVM.IdSupport,
                    // IdUser = modelVM.IdUser,
                    IsActive = modelVM.IsActive,
                    Language = modelVM.Language,
                    Notes = modelVM.Notes,
                    // Platform = modelVM.Platform,
                    Redump = modelVM.Redump,
                    Region = modelVM.Region,
                    ReleaseDate = modelVM.ReleaseDate,
                   // Platform = modelVM.Platform.Name
                   //  Support = modelVM.Support,
                    Title = modelVM.Title
                };
                //  modelDO.UpdateDate = modelVM.UpdateDate;
                //  modelDO.User = modelVM.User;

            }

            return modelDO;
        }

        public static VideoGameVM ConvertDOToVM(this VideoGameDO modelDO )
        {
            VideoGameVM modelVM = null;
            if (modelDO != null){
                modelVM = new VideoGameVM
                {
                    Id = modelDO.Id,
                    BackCover = modelDO.BackCover,
                    BarCode = modelDO.BarCode,
                    CoverPage = modelDO.CoverPage??null,
                    //  CreateDate = modelDO.CreateDate,
                    Description = modelDO.Description,
                    Developer = modelDO.Developer,
                    Distributor = modelDO.Distributor,
                    Genre = modelDO.Genre,
                    IdSystem = modelDO.IdSystem,
                    IdSupport = modelDO.IdSupport,
                    // IdUser = modelDO.IdUser,
                    IsActive = modelDO.IsActive,
                    Language = modelDO.Language,
                    Notes = modelDO.Notes,
                    //  Platform = modelDO.Platform,
                    Redump = modelDO.Redump,
                    Region = modelDO.Region,
                    ReleaseDate = modelDO.ReleaseDate,
                    Title = modelDO.Title,
                    //  UpdateDate = modelDO.UpdateDate,
                    //  User = modelDO.User
                };
                 if (modelDO.Support != null)
                 {
                    modelVM.Support = modelDO.Support.Name ?? string.Empty;
                 }
                 else
                 {
                    modelVM.Support = string.Empty;
                 }
                 if (modelDO.Platform != null)
                 {
                    modelVM.Platform = modelDO.Platform.Name;
                 }
                 else
                 {
                    modelVM.Platform = string.Empty;
                 }
                if (modelDO.System != null)
                {
                    modelVM.System = modelDO.System.Name;
                }
                else
                {
                    modelVM.System = string.Empty;
                }
            }
            return modelVM;
        }
    }

    }
