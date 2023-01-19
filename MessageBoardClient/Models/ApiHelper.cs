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

    public static async void Post(string newUsers)
    {
      RestClient client = new RestClient("http://localhost:5000/");
      RestRequest request = new RestRequest($"api/users", Method.Post);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newUsers);
      await client.PostAsync(request);
    }

    // public static async Task Post (string content, string endpoint)
    // {
    //     // RestClient client = new RestClient("http://localhost:5000/");
    //     // RestRequest request = new RestRequest(endpoint, Method.Post)
    //     //     .AddHeader("Content-Type", "application/json")
    //     //     .AddBody(newUsers);
    //     // await client.PostAsync(request);
    //     var client = new HttpClient {BaseAddress = new Uri("http://localhost:5000")};
    //     var data = new System.Net.Http.StringContent(content, Encoding.UTF8, "application/json");
    //     var response = await client.PostAsync(endpoint, data); 
    //     if (response.IsSuccessStatusCode)
    //     {
    //         Console.WriteLine(response.Content);
    //     } else {
    //         Console.WriteLine(JsonConvert.SerializeObject(response.Content));
    //     }
    // }
  }
}