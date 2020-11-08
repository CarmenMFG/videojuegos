using System.Collections.Generic;
using System.Threading.Tasks;
using Videogames.API.ViewModels;
using Videogames.Business.DOModels;

namespace Videogames.API.Extensions
{
    public static class SystemVMExtensions
    {
        //public static SystemDO ConvertVMToDO(this SystemVM modelVM)
        //{
        //    var modelDO = new SystemDO();

        //    modelDO.Description = modelVM.Description;
        //    modelDO.Id = modelVM.Id;
        //    modelDO.Name = modelVM.Name;
        //    modelDO.IdPlatform = modelVM.IdPlatform;
        //    return modelDO;

        //}

        public static SystemVM ConvertDOToVM(this SystemDO modelDO)
        {
            var modelVM = new SystemVM
            {
                Description = modelDO.Description,
                Id = modelDO.Id,
                Name = modelDO.Name,
                Platform = modelDO.Platform.Name

            };


            return modelVM;

        }
        public static List<SystemVM> ConvertDOToVMs(this List<SystemDO> modelsDO)
        {
            var listSystemsVM = new List<SystemVM>();
            foreach ( SystemDO sys in modelsDO)
            {
                var model = sys.ConvertDOToVM();
                listSystemsVM.Add(model);

            }
          
            return listSystemsVM;

        }

    }
}