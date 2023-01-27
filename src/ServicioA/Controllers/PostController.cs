using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ServicioA.Dtos;

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
            List<PostDto> postList = new();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    postList = JsonConvert.DeserializeObject<List<PostDto>>(apiResponse);
                }
            }
            return Ok(postList);
        }

        [HttpGet("posts/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            PostDto post = new();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"https://jsonplaceholder.typicode.com/posts/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    post = JsonConvert.DeserializeObject<PostDto>(apiResponse);
                }
            }
            return Ok(post);
        }
    }
}