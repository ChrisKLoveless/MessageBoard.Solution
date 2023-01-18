using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace MessageBoard.Models
{
    public class Post
    {
        [Required]
        public string Body { get; set; }
        [Required]
        public int UsersId { get; set; }
        [Required]
        public int ThreadsId { get; set; }
        [Required]
        public int PostId { get; set; }

        public static async Task<List<Post>> GetPostsAsync()
        {
            RestClient client = new RestClient("http://localhost:5000/");
            RestRequest request = new RestRequest($"api/posts", Method.Get);
            RestResponse response = await client.GetAsync(request);
            var result = response.Content;

            JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
            List<Post> postList = JsonConvert.DeserializeObject<List<Post>>(jsonResponse.ToString());

            return postList;
        }
    }
}