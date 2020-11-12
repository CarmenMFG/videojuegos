using System;
using System.Collections.Generic;
using System.Text;
using Videogames.Business.DOModels;
using Videogames.Repository.Entities;

namespace Videogames.Business.Extensions
{
    public static class SupportDOExtension
    {
        public static SupportEntity ConvertDOToEntity(this SupportDO modelDO)
        {
            SupportEntity modelEntity = null;
            if (modelDO != null)
            {
                modelEntity = new SupportEntity()
                {
                    Id = modelDO.Id,
                    Name = modelDO.Name,
                    Description = modelDO.Description,

                };

            }
            return modelEntity;
        }
        public static SupportDO ConvertEntityToDO(this SupportEntity modelEntity)
        {
            SupportDO modelDO = null;
           
            if (modelEntity != null) {
                modelDO = new SupportDO()
                {
                    Id = modelEntity.Id,
                    Name = modelEntity.Name,
                    Description = modelEntity.Description,

                };
            }
            
            return modelDO;
        }
        public static List<SupportDO> ConvertEntitiesToDOs(this List<SupportEntity> modelEntities)
        {
            List<SupportDO> listSupportDO = null;
            if (modelEntities != null)
            {
                listSupportDO = new List<SupportDO>();

                foreach (SupportEntity sys in modelEntities)
                {
                    var model = sys.ConvertEntityToDO();
                    listSupportDO.Add(model);
                }

            }
             return listSupportDO;
        }

    }
}
