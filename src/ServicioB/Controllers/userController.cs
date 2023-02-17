using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ServicioB.Dtos;
using System.Net.Http;

namespace ServicioB.Controllers
{
    [ApiController]
    [Route("")]
    public class userController : ControllerBase
    {
        private readonly ILogger<userController> _logger;

        public userController(ILogger<userController> logger)
        {
            _logger = logger;
        }

        [HttpGet("users")]
        public async Task<IActionResult> Get()
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/users");
            string apiResponse = await response.Content.ReadAsStringAsync();
            var userList = JsonConvert.DeserializeObject<List<UserDto>>(apiResponse);

            return Ok(userList);
        }

        [HttpGet("users/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync($"https://jsonplaceholder.typicode.com/users/{id}");
            string apiResponse = await response.Content.ReadAsStringAsync();
            var post = JsonConvert.DeserializeObject<UserDto>(apiResponse);

            return Ok(post);
        }

    }
}