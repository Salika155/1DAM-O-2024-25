using Microsoft.AspNetCore.Mvc;

namespace ChessApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChessController : ControllerBase
    {

        private IDatabase _database;
        public ChessController(IDatabase database)
        {
            _database = database;
        }

        //[HttpPost]
        //public Requests.AvailablePosition.Response GetAvailablePositions(Requests.AvailablePosition.Request request)
        //{
            
        //}
        
    }
}
