using System.Collections.Generic;
using Videogames.Business.DOModels;
using Videogames.Repository.Entities;

public static class SystemDOExtension
{
    public static SystemEntity ConvertDOToEntity(this SystemDO modelDO)
    {
        var modelEntity = new SystemEntity()
        {
            Id = modelDO.Id,
            Name = modelDO.Name,
            Description = modelDO.Description,
            IdPlatform = modelDO.IdPlatform
        };
        return modelEntity;
    }
    public static SystemDO ConvertEntityToDO(this SystemEntity modelEntity)
    {
        var modelDO= new SystemDO()
        {
            Id = modelEntity.Id,
            Name = modelEntity.Name,
            Description = modelEntity.Description,
            IdPlatform = modelEntity.IdPlatform,
            Platform= new PlatformDO()
            {
                Id=modelEntity.Platform.Id,
                Name=modelEntity.Platform.Name,
                Description=modelEntity.Platform.Description
            }
        };
        return modelDO;
    }
    public static List<SystemDO> ConvertEntitiesToDOs(this List<SystemEntity> modelEntities)
    {
        var listSystemDO = new List<SystemDO>();
       
        foreach (SystemEntity sys in modelEntities)
        {
              var model = sys.ConvertEntityToDO();
              listSystemDO.Add(model);
        }
       
        return listSystemDO;
    }
}

