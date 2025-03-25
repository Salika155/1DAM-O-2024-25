using Microsoft.AspNetCore.Mvc;

namespace ChessApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChessController : ControllerBase
    {
        [HttpPost]
        public Requests.AvailablePosition.Response GetAvailablePositions(Requests.AvailablePosition.Request request)
        {
            return null;
        }
        
    }
}
