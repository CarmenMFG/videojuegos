﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Videogames.API.ViewModels;
using Videogames.Repository.Interfaces;
using Videogames.API.Extensions;
using Videogames.API.Interface;
using Videogames.Business.DOModels;

namespace Videogames.API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IUserRepository _userReppository;
        private readonly ITokenService _tokenService;
        public AccountController(IUserRepository userReppository,ITokenService tokenService)
        {
            _userReppository = userReppository;
            _tokenService = tokenService;

        }

        [HttpPost("register")]
        public ActionResult<TokenVM> Register(AppUserVM appUser)
        {
            if (UserExist(appUser.User))
            {
                return BadRequest("Usuario ya existe");
            }

            using var hmac = new HMACSHA512();
            var user = new UserVM
            {
                User = appUser.User.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(appUser.Password)),
                PasswordSalt = hmac.Key,
                Email = appUser.Email,
                IdRol = 2 //Permiso de usuario
            };

            var id = _userReppository.CreateUser(user.ConvertVMToEntity());

            user.Id = id;


            return new TokenVM { UserName=user.User,Token=_tokenService.CreateToken(user)};
        }

        private bool UserExist(string userName)
        {
            return _userReppository.ExistUser(userName);
        }

        [HttpPost("login")]
        public ActionResult<TokenVM> Login(LoginVM login)
        {
            var userVM = _userReppository.GetUser(login.User).ConvertDOToVM();

            if (userVM == null) { return Unauthorized("Usuario Inválido"); };
            using var hmac = new HMACSHA512(userVM.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(login.Password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != userVM.PasswordHash[i]) { return Unauthorized("Usuario Inválido"); };
            }

            return new TokenVM { UserName = userVM.User, Token = _tokenService.CreateToken(userVM) };


        }
    }
}
