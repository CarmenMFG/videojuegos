using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videogames.Repository.Data;
using Videogames.Repository.Entities;
using Videogames.Repository.Interfaces;

namespace Videogames.Repository.Repositories
{
    public class UserRepository :IUserRepository
    {
        private VideogameContext _context;
        public UserRepository(VideogameContext context)
        {
            _context = context;
        }

        public UserEntity CreateUser(UserEntity user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
               return GetUser(user.User);

            }
            catch
            {
                return null;
            }
           
        }
        public bool DeactiveUser(int id)
        {
            try
            {
                UserEntity userDeactived = _context.Users.FirstOrDefault(u => u.Id == id);
                    userDeactived.IsActive = false;
                    _context.SaveChanges();
                    return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool ActiveUser(int id)
        {
            try
            {
                UserEntity userActived = _context.Users.FirstOrDefault(u => u.Id == id);
                userActived.IsActive = true;
                _context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool ChangeRoleAdmin(int id)
        {
            try
            {
                UserEntity user= _context.Users.FirstOrDefault(u => u.Id == id);
                user.IdRol = _context.Roles.Where(r => r.Name == "admin").First().Id;
                _context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        
        public bool ExistUser(string userName)
        {
            return _context.Users.Where(u => u.User == userName).Count() > 0;
        }
        public UserEntity GetUser(string username)
        {
            return _context.Users.Include(u=>u.Rol).SingleOrDefault(u => u.User == username);
        }
        public List<UserEntity> GetUsers()
        {
            var list= _context.Users.Include(us=>us.Rol).ToList();
            return list;
        }

    }

}
