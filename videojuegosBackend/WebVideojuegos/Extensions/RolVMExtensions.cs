using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Videogames.API.ViewModels;
using Videogames.Business.DOModels;

namespace Videogames.API.Extensions
{
    public static class RolVMExtensions
    {
        public static RolDO ConvertVMToDO(this RolVM modelVM)
        {
            var modelDO = new RolDO();

            modelDO.Description = modelVM.Description;
            modelDO.Id = modelVM.Id;
            modelDO.Name = modelVM.Name;
            modelDO.Users = modelVM.Users;
          
            return modelDO;

        }

        public static RolVM ConvertDOToVM(this RolDO modelDO)
        {
            var modelVM = new RolVM();

            modelVM.Description = modelDO.Description;
            modelVM.Id = modelDO.Id;
            modelVM.Name = modelDO.Name;
            modelVM.Users = modelDO.Users;

            return modelVM;

        }
    }
}
