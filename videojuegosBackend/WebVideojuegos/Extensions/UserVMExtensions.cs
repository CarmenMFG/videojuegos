using Videogames.API.ViewModels;

using Videogames.Business.DOModels;
namespace Videogames.API.Extensions
{
    public static class UserVMExtensions
    {
        public static UserDO ConvertVMToDO(this UserVM modelVM)
        {
            var modelDO = new UserDO();

            modelDO.Email = modelVM.Email;
            modelDO.Id = modelVM.Id;
            modelDO.IdRol = modelVM.IdRol;
            modelDO.Password = modelVM.Password;
            modelDO.Rol = modelVM.Rol;
            modelDO.User = modelVM.User;
            modelDO.VideoGames = modelVM.VideoGames;

            return modelDO;
        }
        public static UserVM ConvertDOToVM(this UserDO modelDO)
        {
            var modeVM = new UserVM();

            modeVM.Email = modelDO.Email;
            modeVM.Id = modelDO.Id;
            modeVM.IdRol = modelDO.IdRol;
            modeVM.Password = modelDO.Password;
            modeVM.Rol = modelDO.Rol;
            modeVM.User = modelDO.User;
            modeVM.VideoGames = modelDO.VideoGames;

            return modeVM;
        }

    }
    }
