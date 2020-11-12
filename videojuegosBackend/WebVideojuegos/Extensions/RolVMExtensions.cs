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

            RolDO modelDO = null;
            if (modelVM != null)
            {
                modelDO = new RolDO{
                    Description = modelVM.Description,
                    Id = modelVM.Id,
                    Name = modelVM.Name,
                    Users = modelVM.Users
                };
            }
                return modelDO;

        }

        public static RolVM ConvertDOToVM(this RolDO modelDO)
        {
            RolVM modelVM = null;
            if (modelDO != null)
            {
                modelVM = new RolVM{
                    Description = modelDO.Description,
                    Id = modelDO.Id,
                    Name = modelDO.Name,
                    Users = modelDO.Users
                };
             }

            return modelVM;

        }
    }
}
