﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public int CreateUser(UserEntity user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return user.Id;
        }
        public bool ExistUser(string userName)
        {
            return _context.Users.Where(u => u.User == userName).Count() > 0;
        }
        public UserEntity GetUser(string username)
        {
            return _context.Users.SingleOrDefault(u => u.User == username);
        }
    }

}