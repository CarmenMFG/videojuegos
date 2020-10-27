using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Videogames.Business;


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
    }
}
