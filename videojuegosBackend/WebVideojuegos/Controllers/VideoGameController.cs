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
        [HttpGet]
        public ActionResult GetVideoGame(int id)
        {
            //_business.CreateVideoGame();

            return Ok("todo ha ido bien");
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
    }
}
