﻿using System;
using System.Collections.Generic;
using System.Text;
using Videogames.Repository.Entities;

namespace Videogames.Repository.Interfaces
{
    public interface IUserRepository
    {
        public int CreateUser(UserEntity user);
        public bool ExistUser(string userName);
        public UserEntity GetUser(string username);
    }
}