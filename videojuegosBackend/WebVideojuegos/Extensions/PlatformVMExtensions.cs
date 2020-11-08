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
            PlatformDO modelDO = null;
            if (modelVM != null)
            {
                modelDO = new PlatformDO
                {
                    Description = modelVM.Description,
                    Id = modelVM.Id,
                    Name = modelVM.Name,
                    Systems = modelVM.Systems
                };
            }
             return modelDO;

        }

        public static PlatformVM ConvertDOToVM(this PlatformDO modelDO)
        {
            PlatformVM modelVM = null;
            if (modelDO != null)
            {
                modelVM = new PlatformVM
                {
                    Description = modelDO.Description,
                    Id = modelDO.Id,
                    Name = modelDO.Name,
                    Systems = modelDO.Systems
                };
            }

            return modelVM;

        }

    }
}
