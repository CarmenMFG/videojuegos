using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Videogames.API.ViewModels;
using Videogames.Business.DOModels;

namespace Videogames.API.Extensions
{
    public static class SupportVMExtensions
    {
        public static SupportDO ConvertVMToDO(this SupportVM modelVM)
        {
            var modelDO = new SupportDO();

            modelDO.Description = modelVM.Description;
            modelDO.Id = modelVM.Id;
            modelDO.Name = modelVM.Name;
            modelDO.VideoGames = modelVM.VideoGames;

            return modelDO;

        }

        public static SupportVM ConvertDOToVM(this SupportDO modelDO)
        {
            var modelVM = new SupportVM();

            modelVM.Description = modelDO.Description;
            modelVM.Id = modelDO.Id;
            modelVM.Name = modelDO.Name;
            modelVM.VideoGames = modelDO.VideoGames;

            return modelVM;

        }
    }
}
