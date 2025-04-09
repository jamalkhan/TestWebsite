using bleak.Api.Rest;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

namespace TestWebsite.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        // GET: api/weather
        [HttpGet]
        public object GetWeather()
        {
            string apiKey = "TODO REPLACE ME"; // Replace with your WeatherAPI key
            string zipCode = "10001"; // Replace with the desired zip code
            string url = $"http://api.weatherapi.com/v1/current.json?key={apiKey}&q={zipCode}";

            var serializer = new bleak.Api.Rest.JsonSerializer();
            var restManager = new RestManager(serializer, serializer);
            var results = restManager.ExecuteRestMethod<WeatherResponse,string>(uri: new Uri(url), HttpVerbs.GET);
            return results.Results;
        }

        // POST: api/weather
        [HttpPost]
        public IActionResult CreateWeather([FromBody] object weatherData)
        {
            // Stub for creating weather data
            return Created("", new { Message = "Weather data created" });
        }

        // PUT: api/weather/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateWeather(int id, [FromBody] object weatherData)
        {
            // Stub for updating weather data
            return Ok(new { Message = $"Weather data with ID {id} updated" });
        }

        // DELETE: api/weather/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteWeather(int id)
        {
            // Stub for deleting weather data
            return Ok(new { Message = $"Weather data with ID {id} deleted" });
        }
    }
}