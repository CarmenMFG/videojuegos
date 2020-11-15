using Videogames.API.ViewModels;

using Videogames.Business.DOModels;
using Videogames.Repository.Entities;

namespace Videogames.API.Extensions
{
    public static class UserVMExtensions
    {
        public static UserEntity ConvertVMToEntity(this UserVM modelVM)
        {
            UserEntity modelentity = null;

            if ( modelVM != null)
            {
                modelentity = new UserEntity
                {
                    Email = modelVM.Email,
                    Id = modelVM.Id,
                    IdRol = modelVM.IdRol,
                    User = modelVM.User,
                    PasswordHash = modelVM.PasswordHash,
                    PasswordSalt = modelVM.PasswordSalt
                };

            }
            



            return modelentity;
        }
        public static UserVM ConvertDOToVM(this UserEntity modelEntity)
        {
            UserVM modeVM = null;
            if (modelEntity != null)
            {
                modeVM = new UserVM
                {
                    Email = modelEntity.Email,
                    Id = modelEntity.Id,
                    IdRol = modelEntity.IdRol,
                    Rol = modelEntity.Rol.Name,
                    User = modelEntity.User,
                    PasswordHash = modelEntity.PasswordHash,
                    PasswordSalt = modelEntity.PasswordSalt
                };

            }
            return modeVM;
        }

    }
    }
