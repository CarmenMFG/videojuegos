using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using System;
using Microsoft.EntityFrameworkCore;
using Videogames.Repository.Interfaces;

namespace Videogames.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : BaseApiController
    {
        private readonly IUserRepository _userReppository;
        public UserController(IUserRepository userReppository)
        {
            _userReppository = userReppository;
        }



    }
}
