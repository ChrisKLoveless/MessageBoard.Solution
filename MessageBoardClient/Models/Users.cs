using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace MessageBoard.Models
{
    public class Users
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int UsersId { get; set; }


        public static async Task<List<Users>> GetAllUsersAsync()
        {
            RestClient client = new RestClient("http://localhost:5000/");
            RestRequest request = new RestRequest($"api/users", Method.Get);
            RestResponse response = await client.GetAsync(request);
            var result = response.Content;

            JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
            List<Users> usersList = JsonConvert.DeserializeObject<List<Users>>(jsonResponse.ToString());

            return usersList;
        }

        public static async Task<Users> GetUserAsync(int id)
        {
            List<Users> allUsers = await Users.GetAllUsersAsync();
            Users thisUser = allUsers.FirstOrDefault(us => us.UsersId == id);
            return thisUser;
        }
    }
}
