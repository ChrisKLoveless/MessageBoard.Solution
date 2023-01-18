using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MessageBoard.Models
{
    public class Users
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int UsersId { get; set; }


        public static List<Users> GetUsers()
        {
            var apiCallTask = ApiHelper.GetAll();
            var result = apiCallTask.Result;

            JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
            List<Users> usersList = JsonConvert.DeserializeObject<List<Users>>(jsonResponse.ToString());

            return usersList;
        }
    }
}
