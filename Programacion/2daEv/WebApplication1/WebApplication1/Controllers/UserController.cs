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

        [HttpPost]
        public UserLogin.Response LoginUser(UserLogin.Request request)
        {
            try
            {
                //return new UserLogin.Response(request.NickName, true);
                _database.AddUser(request.NickName);
                return new UserLogin.Response(request.NickName, true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error");
                return new UserLogin.Response(request.NickName, false);
            }
           

        }


    }
}
