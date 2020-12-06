using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Videogames.Repository.Entities;

namespace Videogames.Repository.Interfaces
{
    public interface IUserRepository
    {
        public UserEntity CreateUser(UserEntity user);
        public bool ExistUser(string userName);
        public UserEntity GetUser(string username);
        public List<UserEntity> GetUsers();
        public bool DeactiveUser(int id);
        public bool ActiveUser(int id);
        public bool ChangeRoleAdmin(int id);
    }
}
