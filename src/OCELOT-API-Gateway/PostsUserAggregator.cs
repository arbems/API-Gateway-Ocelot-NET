using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using Ocelot.Middleware;
using Ocelot.Multiplexer;
using System.Net;
using OCELOT_API_Gateway.Dtos;
using System.Net.Http.Headers;

namespace OCELOT_API_Gateway
{
    public class PostsUserAggregator : IDefinedAggregator
    {
        public async Task<DownstreamResponse> Aggregate(List<HttpContext> responses)
        {
            var posts = await responses[0].Items.DownstreamResponse().Content.ReadFromJsonAsync<List<PostDto>>();
            var users = await responses[1].Items.DownstreamResponse().Content.ReadFromJsonAsync<List<UserDto>>();

            posts?.ForEach(post =>
            {
                post.User = users.FirstOrDefault(a => a.Id == post.UserId);
            });

            var jsonString = JsonConvert.SerializeObject(posts, Formatting.Indented, new JsonConverter[] { new StringEnumConverter() });

            var stringContent = new StringContent(jsonString)
            {
                Headers = { ContentType = new MediaTypeHeaderValue("application/json") }
            };

            return new DownstreamResponse(stringContent, HttpStatusCode.OK, new List<KeyValuePair<string, IEnumerable<string>>>(), "OK");
        }
    }
}
