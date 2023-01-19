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

    public static async void PutUsers(int id, string newUser)
    {
      RestClient client = new RestClient("http://localhost:5000/");
      RestRequest request = new RestRequest($"api/users/{id}", Method.Put);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newUser);
      await client.PutAsync(request);
    }

    public static async void PostThreads(string newThreads)
    {
      RestClient client = new RestClient("http://localhost:5000/");
      RestRequest request = new RestRequest($"api/threads", Method.Post);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newThreads);
      await client.PostAsync(request);
    }

    public static async void PutThreads(int id, string newThreads)
    {
      RestClient client = new RestClient("http://localhost:5000/");
      RestRequest request = new RestRequest($"api/threads/{id}", Method.Put);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newThreads);
      await client.PutAsync(request);
    }


    public static async void PostPost(string newPost)
    {
      RestClient client = new RestClient("http://localhost:5000/");
      RestRequest request = new RestRequest($"api/posts", Method.Post);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newPost);
      await client.PostAsync(request);
    }

    public static async void PutPost(int id, string newPost)
    {
      RestClient client = new RestClient("http://localhost:5000/");
      RestRequest request = new RestRequest($"api/posts/{id}", Method.Put);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newPost);
      await client.PutAsync(request);
    }
  }
}