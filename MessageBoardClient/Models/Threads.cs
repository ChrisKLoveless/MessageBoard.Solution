using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using RestSharp;

namespace MessageBoard.Models 
{
  public class Threads
  {
    [Required]
    public string Title { get; set; }
    [Required]
    public int UsersId { get; set; }
    [Required]
    public int ThreadsId { get; set; }

    public static async Task<List<Threads>> GetThreadsAsync()
        {
            RestClient client = new RestClient("http://localhost:5000/");
            RestRequest request = new RestRequest($"api/threads", Method.Get);
            RestResponse response = await client.GetAsync(request);
            var result = response.Content;
            // var result = apiCallTask.Result;

            JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
            List<Threads> threadsList = JsonConvert.DeserializeObject<List<Threads>>(jsonResponse.ToString());

            return threadsList;
        }
  }
}