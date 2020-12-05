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
             return  _context.Users.Include(us=>us.Rol).ToList();
        }

    }

}
