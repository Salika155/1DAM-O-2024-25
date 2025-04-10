using Microsoft.AspNetCore.Mvc;

namespace ChessApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChessController : ControllerBase
    {
        private IDatabase _database;
        private ILogger<ChessController> _logger;
        public ChessController(IDatabase database, ILogger<ChessController> logger)
        {
            _database = database;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult GetMatch(Requests.GetMatch.Request request)
        {
            try
            {
                Requests.GetMatch.Response response = new Requests.GetMatch.Response();
                List<Requests.GetMatch.Response.Figure> figures = new();
                var match = _database.GetMatch(request.matchName);
                for (int i = 0; i < match.Figures.Length; i++)
                {
                    var figure = match.Figures[i];
                    figures.Add(new Requests.GetMatch.Response.Figure(
                        figure.Type,
                        figure.Color,
                        figure.X,
                        figure.Y));
                }
                response.Figures = figures.ToArray();
                    return Ok(response);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error: " + ex.Message);
                return BadRequest(new Requests.GetMatch.Response());
            }
        }
        //public Requests.AvailablePosition.Response GetAvailablePositions(Requests.AvailablePosition.Request request)
        //{

        //}

    }
}
