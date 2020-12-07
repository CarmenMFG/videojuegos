
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
                    Description = modelVM.Description,
                    Developer = modelVM.Developer,
                    Distributor = modelVM.Distributor,
                    Genre = modelVM.Genre,
                    IdSystem = modelVM.IdSystem,
                    IdSupport = modelVM.IdSupport,
                    IsActive = modelVM.IsActive,
                    Language = modelVM.Language,
                    Notes = modelVM.Notes,
                    Redump = modelVM.Redump,
                    Region = modelVM.Region,
                    ReleaseDate = modelVM.ReleaseDate,
                    Title = modelVM.Title
                };
               

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
