using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Videogames.API.ViewModels;
using Videogames.Business.DOModels;

namespace Videogames.API.Extensions
{
    public static class PlatformVMExtensions
    {
        public static PlatformDO ConvertVMToDO(this PlatformVM modelVM)
        {
            var modelDO = new PlatformDO();

            modelDO.Description = modelVM.Description;
            modelDO.Id = modelVM.Id;
            modelDO.Name = modelVM.Name;
            modelDO.VideoGames = modelVM.VideoGames;

            return modelDO;

        }

        public static PlatformVM ConvertDOToVM(this PlatformDO modelDO)
        {
            var modelVM = new PlatformVM();

            modelVM.Description = modelDO.Description;
            modelVM.Id = modelDO.Id;
            modelVM.Name = modelDO.Name;
            modelVM.VideoGames = modelDO.VideoGames;

            return modelVM;

        }

    }
}
