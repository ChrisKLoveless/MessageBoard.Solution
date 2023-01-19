using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace MessageBoard.Models
{
  public class ApiHelper
  {
    public static async Task<string> GetAll()
    {
      List<Users> allUsers = await Users.GetAllUsersAsync();
      return allUsers.ToString();
    }

    public static async void PostUsers(string newUsers)
    {
      RestClient client = new RestClient("http://localhost:5000/");
      RestRequest request = new RestRequest($"api/users", Method.Post);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newUsers);
      await client.PostAsync(request);
    }

    public static async void PostThreads(string newThreads)
    {
      RestClient client = new RestClient("http://localhost:5000/");
      RestRequest request = new RestRequest($"api/threads", Method.Post);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newThreads);
      await client.PostAsync(request);
    }


    public static async void PostPost(string newPost)
    {
      RestClient client = new RestClient("http://localhost:5000/");
      RestRequest request = new RestRequest($"api/posts", Method.Post);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newPost);
      await client.PostAsync(request);
    }
  }
}