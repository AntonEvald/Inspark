using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Inspark.Models;
using System.Collections.Generic;

namespace Inspark.Services
{
    public class ApiServices
    {

        public async Task<bool> RegisterAsync(string role, string email,string password)
        {
            var client = new HttpClient();
            var model = new User
            {
                UserName = email,
                Password = password,
                Email = email,
                Role = role
                //FirstName = firstname,
                //LastName = lastname,
                //PhoneNumber = phonenumber

            };

            var json = JsonConvert.SerializeObject(model);
            HttpContent content = new StringContent(json);
            var response = await client.PostAsync("https://insparkwebapi.azurewebsites.net/api/user",content);

            return response.IsSuccessStatusCode;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("https://insparkwebapi.azurewebsites.net/api/user");
            var json = response.ToString();
            var list = JsonConvert.DeserializeObject<List<User>>(json);
            return list;
        }

    }
}
