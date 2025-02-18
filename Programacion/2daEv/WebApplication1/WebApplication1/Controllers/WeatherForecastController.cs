using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //anotacion de arriba dice que clase de abajo sea apicontroller -> recorre las clases buscando anotacion apicontroller
    public class WeatherForecastController : ControllerBase
    {
       
        [HttpGet]
        public List<WeatherForecast> Get()
        {
            var l = new List<WeatherForecast>();

            var w1 = new WeatherForecast()
            {
                Name = "Sofia",
            };
            l.Add(w1);

            var w2 = new WeatherForecast()
            {
                Name = "Adrian"
            };
            l.Add(w2);

            return l;
        }
    }
}
