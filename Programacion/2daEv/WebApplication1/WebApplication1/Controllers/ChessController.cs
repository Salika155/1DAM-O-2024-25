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

        [HttpPost("avpos")]
        public IActionResult GetAvailablePositions(Requests.GetAvailablePosition.Request request)
        {
            List<Requests.GetAvailablePosition.Coordinates> list = new();
            try
            {
                var response = new Requests.GetAvailablePosition.Response();
                var position = _database.GetAvailablePositions(request.playerName, request.x, request.y);

                    
                foreach(var coords in position.Coords)
                {
                    list.Add(new Requests.GetAvailablePosition.Coordinates(coords, ));
                }
                response.Coords = list.ToArray();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error " + ex.Message);
                return BadRequest(new Requests.GetAvailablePosition.Response());
            }
            
        }

        [HttpPost("move")]
        public IActionResult MoveFigure(Requests.MoveFigure.Request request)
        {
            try
            {
                _database.Move(
                    request.PlayerName, 
                    request.SourceX, 
                    request.SourceY, 
                    request.DestinationX, 
                    request.DestinationY);
                return Ok(new Requests.MoveFigure.Response(true));
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error " + ex.Message);
                return BadRequest(new Requests.MoveFigure.Response(false));
            }
        }

        [HttpPost("status")]
        public IActionResult GetMatchStatus(Requests.GetMatchStatus.Request request)
        {
            try
            {
                var status = _database.GetMatchInfo(request.matchName);
                var response = new Requests.GetMatchStatus.Response();
                response.Name = status.Name;
                response.OponentId = status.OponentId;
                response.NextPlayerId = status.NextPlayerId;
                response.IsStarted = status.IsStarted;
                response.IsCompleted = status.IsCompleted;
                response.WinnerId = status.WinnerId;
                response.OwnerId = status.OwnerId;
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error " + ex.Message);
                return BadRequest(new Requests.GetMatch.Response());
            }
        }

        [HttpPost("match")]
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
