using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using System;
using Microsoft.EntityFrameworkCore;
using Videogames.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Videogames.API.ViewModels;
using Microsoft.AspNetCore.Authorization;

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

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<UserVM>> GetUsers()
        {
            var list = _userReppository.GetUsers();
            return new List<UserVM>();
        }


       /* [HttpGet("{id}")]
        [Authorize]
        public ActionResult<UserVM> GetUser(int id)
        {
            var user = _userReppository.GetUser(id.ToString());
            return new UserVM();
        }*/
    }

}
