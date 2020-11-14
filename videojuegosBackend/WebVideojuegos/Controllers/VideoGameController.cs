using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Videogames.API.Extensions;
using Videogames.API.ViewModels;
using Videogames.Business;
using Videojuegos.API.ViewModels;
using Newtonsoft.Json.Serialization;
using System;

namespace  Videojuegos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VideoGameController : ControllerBase
    {

        //private readonly ILogger<VideoGameController> _logger;

        private readonly BusinessManagment _business;
        public VideoGameController(BusinessManagment business)
        {
            _business = business;
        }
    
        [HttpPost]
        public JsonResult CreateVideoGame(VideoGameVM model)
        {
            var result = new ResultVM() { Message = "", Success = true };
            if (model != null)
            {
                try
                {
                    bool res = _business.CreateVideoGame(model.ConvertVMToDO(), 1, "administrador");
                    result.StatusCode = 200;
                    result.Message = res ? "Videojuego guardado con éxito" : "No se pudo guardar el videojuego seleccionado";
                }
                catch
                {
                    result.Success = false;
                    result.Message = "No se pudo guardar el videojuego ";
                    result.StatusCode = 500;
                }
            }
            else
            {
                result.Success = false;
                result.Message = "Debe rellenar los datos del videojuego";
                result.StatusCode = 500;
            }
            return new JsonResult(result);
        }

        [HttpPut]
        public JsonResult ModifyVideoGame(VideoGameVM model)
        {
            var result = new ResultVM() { Message = "", Success = true };
            if (model != null)
            {
                try
                {
                    bool res = _business.ModifyVideoGame(model.ConvertVMToDO(), 1, "administrador");

                    result.StatusCode = 200;
                    result.Message = res ? "Videojuego modificado con éxito" : "No se pudo modificar el videojuego seleccionado";

                }
                catch
                {
                    result.Success = false;
                    result.Message = "No se pudo desactivar el videojuego ";
                    result.StatusCode = 500;
                }
            
            }
            else
            {
                result.Success = false;
                result.Message = "Debe seleccionar un videojuego";
                result.StatusCode = 500;

            }
            return new JsonResult(result);
        }


        [HttpDelete("{idVideoGame}")]
        public JsonResult DeactiveVideoGame(int idVideoGame)
        {
            var result = new ResultVM() { Message = "", Success = true };

            try
            {
                bool res = _business.DeactiveVideoGame(idVideoGame, 1, "administrador");
                result.StatusCode = 200;
                result.Message = res ? "Videojuego desactivado con éxito" : "No se puedo desactivar el videojuego seleccionado";
              
            }
            catch
            {
                result.Success = false;
                result.Message = "No se pudo desactivar el videojuego ";
                result.StatusCode = 500;
            }

            return new JsonResult(result);
        }

        [HttpGet]
        public ActionResult GetOkVideoGame()
        {
             return Ok("Todo ha ido bien");

        }
       
        [HttpGet("getAll")]
        public JsonResult GetAllVideoGame()
        {
            var result = new ResultVM() { Message = "", Success = true };

            try
            {
                result.Data = _business.GetAllVideoGame(1, "administrador");
                result.StatusCode = 200;
            }
            catch(Exception ex)
            {
                result.Success = false;
                result.Message = "No se pueden mostrar los videojuegos ";
                result.StatusCode = 500;
            }

            return new JsonResult(result);

        }

        [HttpGet("{idVideoGame}")]
        public JsonResult GetVideoGame(int idVideoGame)
        {
            var result = new ResultVM() { Message = "", Success = true };

            try
                {
                     result.Data = _business.GetVideoGame(idVideoGame, 1, "administrador");
                     result.StatusCode = 200;
                }
            catch
                {
                    result.Success = false;
                    result.Message = "No se puede mostrar el videojuego solicitado";
                    result.StatusCode = 500;
                }

            return new JsonResult(result);

        }

        [HttpGet("systems")]

        public JsonResult GetAllSystems()
        {
           var result = new ResultVM() { Message = "", Success = true };
        
            try
                 {
                      result.Data = _business.GetAllSystems(1, "administrador").ConvertDOToVMs();
                      result.StatusCode = 200;
                  }
             catch
                 {
                       result.Success = false;
                       result.Message = "No se pueden mostrar los sistemas";
                       result.StatusCode = 500;
                  }

            return new JsonResult(result);

        }
        [HttpGet("supports")]

        public JsonResult GetAllSupports()
        {
            var result = new ResultVM() { Message = "", Success = true };
        
            try
                 {
                    result.Data= _business.GetAllSupports(1, "administrador").ConvertDOToVMs();
                    result.StatusCode = 200;
                 }
             catch (Exception ex )
                 {
                           
                    result.Success = false;
                    result.Message = "No se pueden mostrar los soportes";
                    result.StatusCode = 500;
            
             }


            return new JsonResult(result);

        }

         



    }
}
