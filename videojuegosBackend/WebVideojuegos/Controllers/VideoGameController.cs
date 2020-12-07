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

namespace  Videojuegos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VideoGameController : ControllerBase
    {

        //private readonly ILogger<VideoGameController> _logger;

        private readonly BusinessManagment _business;

        public object Configuration { get; private set; }

        public VideoGameController(BusinessManagment business)
        {
            _business = business;
        }
    
        [HttpPost]
        [Authorize]
        public JsonResult SaveVideoGame(VideoGameVM model)
        {
            var result = new ResultVM() { Message = "", Success = true };
            if (model != null)
            {
                try
                {
                    var data = getDataToken(HttpContext.User.Claims.ToList());
                    bool res=false;
                    if (model.IsNew)
                    {
                         res = _business.CreateVideoGame(model.ConvertVMToDO(), data.IdUser, data.RolName);
                    }
                    else
                    {
                         res = _business.ModifyVideoGame(model.ConvertVMToDO(), data.IdUser, data.RolName);
                    }
                   
                    result.Success = res;
                    result.StatusCode = res ? 200 : 500;
                    result.Message = res ? "Game saved successfull" : "Game saved failed";
                }
                catch
                {
                    result.Success = false;
                    result.Message = "Game saved failed";
                    result.StatusCode = 500;
                }
            }
            else
            {
                result.Success = false;
                result.Message = "Error completed form";
                result.StatusCode = 500;
            }
            return new JsonResult(result);
        }

      
        [HttpDelete("{idVideoGame}")]
        [Authorize]
        public JsonResult DeactiveVideoGame(int idVideoGame)
        {
            var result = new ResultVM() { Message = "", Success = true };

            try
            {
                var data = getDataToken(HttpContext.User.Claims.ToList());
                bool res = _business.DeactiveVideoGame(idVideoGame, data.IdUser, data.RolName);
                result.Success = res;
                result.StatusCode = res ? 200 : 500;
                result.Message = res ? "Game desactived successfull" : "Game desactived failed";


            }
            catch
            {
                result.Success = false;
                result.Message = "Game desactived failed";
                result.StatusCode = 500;
            }

            return new JsonResult(result);
        }

        [HttpGet]
        public ActionResult GetOkVideoGame()
        {
             return Ok("Ok");

        }
       
        [HttpGet("getAll")]
        [Authorize]
        public JsonResult GetAllVideoGame()
        {
            var result = new ResultVM() { Message = "", Success = true };

            try
            {
                var data = getDataToken(HttpContext.User.Claims.ToList());
                var res = _business.GetAllVideoGame(data.IdUser, data.RolName);
                result.Data =res.Select( x => x.ConvertDOToVM());
                result.StatusCode = 200;
                result.Success = true;
            }
            catch(Exception ex)
            {
                result.Success = false;
                result.Message = "Games cannot be displayed";
                result.StatusCode = 500;
            }

            return new JsonResult(result);

        }

        [HttpGet("{idVideoGame}")]
        [Authorize]
        public JsonResult GetVideoGame(int idVideoGame)
        {
            var result = new ResultVM() { Message = "", Success = true };

            try
                {
                    var data = getDataToken(HttpContext.User.Claims.ToList());
                     result.Data = _business.GetVideoGame(idVideoGame, data.IdUser, data.RolName);
                     result.StatusCode = 200;
                }
            catch
                {
                    result.Success = false;
                    result.Message = "Unable to display the requested game";
                    result.StatusCode = 500;
                }

            return new JsonResult(result);

        }

        [HttpGet("systems")]
        [Authorize]

        public JsonResult GetAllSystems()
        {
            var result = new ResultVM() { Message = "", Success = true };

            try
            {
                var data = getDataToken(HttpContext.User.Claims.ToList());
                result.Data = _business.GetAllSystems(data.IdUser, data.RolName).ConvertDOToVMs();
                result.StatusCode = 200;
            }
            catch
            {
                result.Success = false;
                result.Message = "Systems cannot be displayed";
                result.StatusCode = 500;
            }

            return new JsonResult(result);

        }

        [HttpGet("supports")]
        [Authorize]

        public JsonResult GetAllSupports()
        {
            var result = new ResultVM() { Message = "", Success = true };

            try
            {
                var data = getDataToken(HttpContext.User.Claims.ToList());
                result.Data = _business.GetAllSupports(data.IdUser, data.RolName).ConvertDOToVMs();
                result.StatusCode = 200;
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Supports cannot be displayed";
                result.StatusCode = 500;

            }


            return new JsonResult(result);

        }

        private TokenData getDataToken(List<Claim> list)
        {
            return new TokenData {  IdUser = int.Parse( list[3].Value), RolName = list[2].Value };
        }
    }
}
