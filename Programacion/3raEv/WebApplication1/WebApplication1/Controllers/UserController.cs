using Microsoft.AspNetCore.Mvc;

namespace ChessApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IDatabase _database;
        //private ILogger _logger;
        private readonly ILogger<UserController> _logger;
        public UserController(IDatabase database, ILogger<UserController> logger)
        {
            _database = database;
            _logger = logger;
        }

        [HttpPost("login")]
        public IActionResult LoginUser(UserLogin.Request request)
        {
            try
            {
                //return new UserLogin.Response(request.NickName, true);
                _database.AddUser(request.NickName);
                return Ok(new UserLogin.Response(request.NickName.ToLower(), true));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error");
                return BadRequest(new UserLogin.Response(request.NickName, false));
            }
        }
        [HttpPost("creatematch")]
        public IActionResult CreateMatch(Requests.CreateMatch.Request request)
        {
            try
            {
                //tiene que devolver un creatematch.Request no hacer uso del metodo.
                return Ok(_database.CreateMatch(request.MatchName, request.OwnerId.ToLower()));
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error" + ex.Message);
                return BadRequest(new Requests.CreateMatch.Request(string.Empty, string.Empty));
            }
            
        }

    }
}
