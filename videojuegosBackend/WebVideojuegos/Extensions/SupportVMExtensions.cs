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
        /* public static SupportDO ConvertVMToDO(this SupportVM modelVM)
         {
             var modelDO = new SupportDO();

             modelDO.Description = modelVM.Description;
             modelDO.Id = modelVM.Id;
             modelDO.Name = modelVM.Name;
             modelDO.VideoGames = modelVM.VideoGames;

             return modelDO;

         }*/

        public static SupportVM ConvertDOToVM(this SupportDO modelDO)
        {
            SupportVM modelVM = null;
            if (modelDO != null) { 
                modelVM = new SupportVM
                {
                    Description = modelDO.Description,
                    Id = modelDO.Id,
                    Name = modelDO.Name,
                    VideoGames = modelDO.VideoGames
                };
             }

            return modelVM;

        }
        public static List<SupportVM> ConvertDOToVMs(this List<SupportDO> modelsDO)
        {
            List<SupportVM> listSupportsVM = null;
            if (modelsDO != null)
            {
                listSupportsVM = new List<SupportVM>();
                foreach (SupportDO sup in modelsDO)
                {
                    var model = sup.ConvertDOToVM();
                    listSupportsVM.Add(model);

                }

            }
           return listSupportsVM;

        }
    }
}
