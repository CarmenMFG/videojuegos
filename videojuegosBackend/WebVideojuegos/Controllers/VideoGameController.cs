using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Videogames.API.Extensions;
using Videogames.Business;
using Videojuegos.API.ViewModels;

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
        public ActionResult CreateVideoGame(VideoGameVM model)
        {
            if (model != null)
            {
                var result = _business.CreateVideoGame(model.ConvertVMToDO(), 1, "administrador");

                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public ActionResult ModifyVideoGame(VideoGameVM model)
        {
            if (model != null)
            {
                var result = _business.ModifyVideoGame(model.ConvertVMToDO(), 1, "administrador");

                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete("{idVideoGame}")]
        public ActionResult DeactiveVideoGame(int idVideoGame)
        {
            if (idVideoGame != null)
            {
                var result = _business.DeactiveVideoGame(idVideoGame, 1, "administrador");

                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet]
        public ActionResult GetOkVideoGame()
        {
             return Ok("Todo ha ido bien");

        }
       
        [HttpGet("getAll")]
        public ActionResult GetAllVideoGame()
        {
            var result = _business.GetAllVideoGame(1, "administrador");

            return Ok(result);
            
        }

        [HttpGet("{idVideoGame}")]
        public ActionResult GetVideoGame(int idVideoGame)
        {
            var result = _business.GetVideoGame(idVideoGame, 1, "administrador");

            return Ok(result);

        }


    }
}
