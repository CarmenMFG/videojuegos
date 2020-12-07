using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Videogames.API.Extensions;
using Videogames.API.ViewModels;
using Videogames.Business;
using Videojuegos.API.ViewModels;
using Newtonsoft.Json.Serialization;
using System;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Security.Claims;
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

        [HttpGet]
        [Authorize]
        public JsonResult GetUsers()
        {
            var result = new ResultVM() { Message = "", Success = true };

            try
            {
                var data = getDataToken(HttpContext.User.Claims.ToList());
                if (data.RolName.ToUpper() == "ADMIN")
                {
                    var res = _userReppository.GetUsers();
                    result.Data = res.Select(x => x.ConvertEntityToVM());
                    result.StatusCode = 200;
                    result.Success = true;

                }
                else
                {
                    result.Success = false;
                    result.Message = "No authorized ";
                    result.StatusCode = 500;

                }


            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Problem load data ";
                result.StatusCode = 500;
            }

            return new JsonResult(result);

        }
        [HttpDelete("{id}")]
        [Authorize]
        public JsonResult DeleteUser(int id)
        {
            var result = new ResultVM() { Message = "", Success = true };
            try
            {
                var data = getDataToken(HttpContext.User.Claims.ToList());
                if (data.RolName.ToUpper() == "ADMIN")
                {
                    var res= _userReppository.DeactiveUser(id);
                    result.Success = res;
                    result.StatusCode = res ? 200 : 500;
                    result.Message = res ? "User successfully deactivated" : "User deactived failed";
                }
                else
                {
                    result.Success = false;
                    result.Message = "No authorized ";
                    result.StatusCode = 500;

                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Problem load data ";
                result.StatusCode = 500;
            }

            return new JsonResult(result);

        }
        [HttpPut("{id}")]
        [Authorize]
        public JsonResult ActiveUser(int id)
        {
            var result = new ResultVM() { Message = "", Success = true };
            try
            {
                var data = getDataToken(HttpContext.User.Claims.ToList());
                if (data.RolName.ToUpper() == "ADMIN")
                {
                    var res = _userReppository.ActiveUser(id);
                    result.Success = res;
                    result.StatusCode = res ? 200 : 500;
                    result.Message = res ? "User successfully activated" : "User actived failed";
                }
                else
                {
                    result.Success = false;
                    result.Message = "No authorized ";
                    result.StatusCode = 500;

                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Problem load data ";
                result.StatusCode = 500;
            }

            return new JsonResult(result);

        }
        [HttpPost("changeRolAdmin")]
        [Authorize]
        public JsonResult ChangeRoleAdmin(DataRoleVM rolVM)
        {
            var result = new ResultVM() { Message = "", Success = true };
            try
            {
                var data = getDataToken(HttpContext.User.Claims.ToList());
                if (data.RolName.ToUpper() == "ADMIN")
                {
                    var res = _userReppository.ChangeRoleAdmin(rolVM.IdUser);
                    result.Success = res;
                    result.StatusCode = res ? 200 : 500;
                    result.Message = res ? "Role successfully changed" : "Role changed failed";
                }
                else
                {
                    result.Success = false;
                    result.Message = "No authorized ";
                    result.StatusCode = 500;

                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Problem load data ";
                result.StatusCode = 500;
            }

            return new JsonResult(result);

        }

        /* [HttpGet("{id}")]
         [Authorize]
         public ActionResult<UserVM> GetUser(int id)
         {
             var user = _userReppository.GetUser(id.ToString());
             return new UserVM();
         }*/

        private TokenData getDataToken(List<Claim> list)
        {
            return new TokenData { IdUser = int.Parse(list[3].Value), RolName = list[2].Value };
        }

    }
}