﻿using Videogames.Business.DOModels;
using Videogames.Repository.Entities;

public static class PlatformDOExtension
{
    public static PlatformEntity ConvertDOToEntity(this PlatformDO modelDO)
    {
        PlatformEntity modelEntity = null;
        if (modelDO != null)
        {
            modelEntity = new PlatformEntity()
            {
                Id = modelDO.Id,
                Name = modelDO.Name,
                Description = modelDO.Description

            };

        }
        return modelEntity;
    }
    public static PlatformDO ConvertEntityToDO(this PlatformEntity modelEntity)
    {
        PlatformDO modelDO = null;
        if(modelEntity != null)
        {
            modelDO = new PlatformDO()
            {
                Id = modelEntity.Id,
                Name = modelEntity.Name,
                Description = modelEntity.Description
            };

        }
        return modelDO;
    }
}

