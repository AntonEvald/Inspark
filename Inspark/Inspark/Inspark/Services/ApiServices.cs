﻿using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Inspark.Models;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using Inspark.Helpers;
using Inspark.Views;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Collections.ObjectModel;
 using System.Runtime.InteropServices.ComTypes;

namespace Inspark.Services
{
    public class ApiServices
    {
        private string ConnectionString = "https://insparkwebapi.azurewebsites.net/";


        public async Task<ObservableCollection<GroupEvent>> GetAllGroupEvents()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(ConnectionString+"api/GroupEvent");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<ObservableCollection<GroupEvent>>(result);
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

            var request = new HttpRequestMessage(HttpMethod.Post, ConnectionString+"token");
            request.Content = new FormUrlEncodedContent(keyValue);
            
            var client = new HttpClient();
            var response = await client.SendAsync(request);
            var jwt = await response.Content.ReadAsStringAsync();
            JObject jwtDynamic = JsonConvert.DeserializeObject<dynamic>(jwt);
            var accessToken = jwtDynamic.Value<string>("access_token");
            var accessTokenExpires = jwtDynamic.Value<DateTime>(".expires");
            Settings.AccessTokenExpires = accessTokenExpires;
            Settings.AccessToken = accessToken;
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RegisterAsync(User user)
        {
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(user);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(ConnectionString+"api/account/register", content);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> EditUser(User user)
        {
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(user);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(ConnectionString+"api/User/" + user.Id.ToString() + "/", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<ObservableCollection<User>> GetAllUsers()
        {
           var client = new HttpClient();
           var response = await client.GetAsync(ConnectionString+"api/User/");
           response.EnsureSuccessStatusCode();
           var result = await response.Content.ReadAsStringAsync();
           var list = JsonConvert.DeserializeObject<ObservableCollection<User>>(result);
           return list;
        }

        public async Task<ObservableCollection<Section>> GetAllSections()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(ConnectionString+"api/Section/");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<ObservableCollection<Section>>(result);
            return list;
        }

        public async Task<User> GetLoggedInUser()
        {
            var userName = Settings.UserName;
            var client = new HttpClient();
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Settings.AccessToken);
            var json = await client.GetStringAsync(ConnectionString+"api/User/GetByUserName/" + userName + "/");
            var user = JsonConvert.DeserializeObject<User>(json);
            return user;
        }
        
        public async Task<User> GetSingelUser(string id)
        { 
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Settings.AccessToken);
            var json = await client.GetStringAsync(ConnectionString+"api/GetUserName/" + id);
            var user = JsonConvert.DeserializeObject<User>(json);
            return user;
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
            var response = await client.PostAsync(ConnectionString+"api/user", content);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> CreateGroup(Group group)
        {
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(group);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://insparkapi2018.azurewebsites.net/api/Group", content);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> CreatePost(NewsPost post)
        {
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(post);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(ConnectionString+"Api/NewsPost", content);

            return response.IsSuccessStatusCode;
        }

        public async Task<ObservableCollection<NewsPost>> GetAllNewsPosts()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(ConnectionString+"api/newspost");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<ObservableCollection<NewsPost>>(result);
            return list;
        }
        
        public async Task<ObservableCollection<Group>> GetAllGroups()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(ConnectionString+"api/Group");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<ObservableCollection<Group>>(result);
            return list;
        }
    }
}
