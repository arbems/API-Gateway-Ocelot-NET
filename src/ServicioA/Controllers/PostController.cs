using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ServicioA.Dtos;
using System.Net.Http;

namespace ServicioA.Controllers
{
    [ApiController]
    [Route("")]
    public class PostController : ControllerBase
    {
        private readonly ILogger<PostController> _logger;

        public PostController(ILogger<PostController> logger)
        {
            _logger = logger;
        }

        [HttpGet("posts")]
        public async Task<IActionResult> Get()
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts");
            string apiResponse = await response.Content.ReadAsStringAsync();
            var postList = JsonConvert.DeserializeObject<List<PostDto>>(apiResponse);

            return Ok(postList);
        }

        [HttpGet("posts/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync($"https://jsonplaceholder.typicode.com/posts/{id}");
            string apiResponse = await response.Content.ReadAsStringAsync();
            var post = JsonConvert.DeserializeObject<PostDto>(apiResponse);

            return Ok(post);
        }
    }
}