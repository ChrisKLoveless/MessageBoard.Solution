using System.Threading.Tasks;
using RestSharp;

namespace MessageBoard.Models
{
    public class ApiHelper
    {
        public static async Task<string> GetAll()
        {
            List<Users> allUsers = await Users.GetAllUsersAsync();
            return allUsers.ToString();
        }
    }
}