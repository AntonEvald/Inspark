using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Inspark.Models;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace Inspark.Services
{
    public class ApiServices
    {
     
        public async Task<bool> RegisterAsync(string firstName, string lastName, string email, string password, string phoneNumber, string section, byte[] pic, bool isLoggedIn)
        {
            var client = new HttpClient();
            var model = new User
            {
                UserName = email,
                Password = password,
                Email = email,
                Section = section,
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber,
                ProfilePicture = pic,
                IsLoggedIn = isLoggedIn
            };

            var json = JsonConvert.SerializeObject(model);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://aktuelltwebapi.azurewebsites.net/api/user", content);

            return response.IsSuccessStatusCode;
        }

        public async Task<List<User>> GetAllUsers()
        {
           var client = new HttpClient();
           var response = await client.GetAsync("http://aktuelltwebapi.azurewebsites.net/api/user");
           response.EnsureSuccessStatusCode();
           var result = await response.Content.ReadAsStringAsync();
           var list = JsonConvert.DeserializeObject<List<User>>(result);
           return list;
        }

    }
}
