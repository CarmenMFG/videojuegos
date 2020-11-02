using System.Threading.Tasks;
using Videogames.API.ViewModels;
using Videogames.Business.DOModels;

namespace Videogames.API.Extensions
{
    public static class SystemVMExtensions
    {
        public static SystemDO ConvertVMToDO(this SystemVM modelVM)
        {
            var modelDO = new SystemDO();

            modelDO.Description = modelVM.Description;
            modelDO.Id = modelVM.Id;
            modelDO.Name = modelVM.Name;
            modelDO.IdPlatform = modelVM.IdPlatform;
            modelDO.Platforms = modelVM.Platforms;
            modelDO.VideoGames = modelVM.VideoGames;

            return modelDO;

        }

        public static SystemVM ConvertDOToVM(this SystemDO modelDO)
        {
            var modelVM = new SystemVM();

            modelVM.Description = modelDO.Description;
            modelVM.Id = modelDO.Id;
            modelVM.Name = modelDO.Name;
            modelVM.IdPlatform = modelDO.IdPlatform;
            modelVM.Platforms = modelDO.Platforms;
            modelVM.VideoGames = modelDO.VideoGames;

            return modelVM;

        }

    }
}