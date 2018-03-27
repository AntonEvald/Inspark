using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Inspark.Models;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using Inspark.Views;

namespace Inspark.Services
{
    public class ApiServices
    {


        public async Task<List<GroupEvent>> GetAllGroupEvents()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://aktuelltwebapi.azurewebsites.net/api/GroupEvent");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<List<GroupEvent>>(result);
            return list;

        }

        public async Task<bool> LoginAsync(string userName, string password)
        {
            var keyValue = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("UserName", userName),
                new KeyValuePair<string, string>("Password", password),
                new KeyValuePair<string, string>("grant_type", "password")
            };

            var request = new HttpRequestMessage(HttpMethod.Post, "http://insparkapi2018.azurewebsites.net/token");
            request.Content = new FormUrlEncodedContent(keyValue);
            
            var client = new HttpClient();
            var response = await client.SendAsync(request);
            return response.IsSuccessStatusCode;


        }

        public async Task<bool> RegisterAsync(string firstName, string lastName, string email, string password, string section, string phoneNumber, byte[] pic, bool isLoggedIn)
        {
            var client = new HttpClient();
            var model = new User
            {
                //UserName = email,
                Password = password,
                Email = email,
                //Section = section,
                //FirstName = firstName,
                //LastName = lastName,
                //Role = "Admin",
                ConfirmPassword = password
                //PhoneNumber = phoneNumber,
                //ProfilePicture = pic,
                //IsLoggedIn = isLoggedIn
            };

            var json = JsonConvert.SerializeObject(model);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://insparkapi2018.azurewebsites.net/api/account/register", content);

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

        public async Task<bool> CreateEvent(string tile, string location, DateTime date, string desc)
        {
            var client = new HttpClient();
             var model = new Event()
            {
                Title = tile,
                Location = location,
                Date = date,
                Description = desc
            };
            var json = JsonConvert.SerializeObject(model);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://aktuelltwebapi.azurewebsites.net/api/user", content);

            return response.IsSuccessStatusCode;
            
        }

    }
}
