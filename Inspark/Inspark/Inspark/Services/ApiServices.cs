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
 using System.Security.Cryptography.X509Certificates;

namespace Inspark.Services
{
    public class ApiServices
    {
        // Connection string for calls to our web api
        private string ConnectionString = "https://insparkwebapi.azurewebsites.net/";


        public async Task<ObservableCollection<GroupEvent>> GetAllGroupEvents()
        {
            // declare a new http client to use for calls to api
            var client = new HttpClient();
            // get data from api
            var response = await client.GetAsync(ConnectionString+"api/GroupEvent");
            // Checks status code that gets returned from api call
            response.EnsureSuccessStatusCode();
            // reades the Json string
            var result = await response.Content.ReadAsStringAsync();
            // Converts to an object from Json
            var list = JsonConvert.DeserializeObject<ObservableCollection<GroupEvent>>(result);
            // reurns list of objects
            return list;

        }

        public async Task<ObservableCollection<GroupPost>> GetAllGroupPosts()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(ConnectionString + "api/grouppost");
            var success = response.IsSuccessStatusCode;
            if (success)
            {
                var result = await response.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<ObservableCollection<GroupPost>>(result);
                return list;
            }
            else
            {
                var list = new ObservableCollection<GroupPost>();
                return list;
            }
        }

        public async Task<bool> LoginAsync(string userName, string password)
        {
            /* gets username and password from viewmodel
             *  an turns them into key value pairs
             */
            var keyValue = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("UserName", userName),
                new KeyValuePair<string, string>("Password", password),
                new KeyValuePair<string, string>("grant_type", "password")
            };

            // creates a http requestmessage.
            var request = new HttpRequestMessage(HttpMethod.Post, ConnectionString+"token");
            request.Content = new FormUrlEncodedContent(keyValue);
            
            var client = new HttpClient();
            // sends message to api and waits for return.
            var response = await client.SendAsync(request);
            // reds return message.
            var jwt = await response.Content.ReadAsStringAsync();
            // converts to Json object.
            JObject jwtDynamic = JsonConvert.DeserializeObject<dynamic>(jwt);
            // gets specifik values from Json object.
            var accessToken = jwtDynamic.Value<string>("access_token");
            var accessTokenExpires = jwtDynamic.Value<DateTime>(".expires");
            // sets properties in settings.cs with values.
            Settings.AccessTokenExpires = accessTokenExpires;
            Settings.AccessToken = accessToken;
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> EditGroupPost(EditPostModel post)
        {
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(post);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(ConnectionString + "api/GroupPost/EditGroupPost", content);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> AddUserToGroup(int groupId, string userId)
        {
            var client = new HttpClient();
            var response = await client.PostAsync(ConnectionString + "api/group/AddUserToGroup/"+groupId+"/"+userId+"/", null);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> EditNewsPost(EditPostModel post)
        {
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(post);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(ConnectionString + "api/NewsPost/EditNewsPost", content);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteGroup(int groupId)
        {
            var client = new HttpClient();
            var response = await client.DeleteAsync(ConnectionString + "api/group/" + groupId + "/");
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteUserFromGroup(int groupId, string userId)
        {
            var client = new HttpClient();
            var response = await client.PostAsync(ConnectionString + "api/Group/RemoveUserFromGroup/" + groupId + "/" + userId + "/",null);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> ChangeGroup(Group group)
        {
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(group);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(ConnectionString + "api/Group/EditGroup/", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteNewsPost(int id)
        {
            var client = new HttpClient();
            var response = await client.DeleteAsync(ConnectionString + "api/NewsPost/" + id.ToString());
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteGroupPost(int id)
        {
            var client = new HttpClient();
            var response = await client.DeleteAsync(ConnectionString + "api/GroupPost/" + id.ToString());
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> CreateGroupPost(GroupPost post)
        {
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(post);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(ConnectionString + "api/GroupPost/AddGroupPost", content);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> ChangePassword(ChangePasswordModel model)
        {
            var client = new HttpClient();
            var token = Settings.AccessToken;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var json = JsonConvert.SerializeObject(model);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync(ConnectionString + "api/Account/ChangePassword", content);

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

        public async Task<bool> EditUser(EditUserModel model)
        {
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(model);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(ConnectionString+"api/User/EditUser", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<ObservableCollection<User>> GetAllUsers()
        {
           var client = new HttpClient();
           var response = await client.GetAsync(ConnectionString+"api/user/");
           response.EnsureSuccessStatusCode();
           var result = await response.Content.ReadAsStringAsync();
           var list = JsonConvert.DeserializeObject<ObservableCollection<User>>(result);
           return list;
        }

        public async Task<ObservableCollection<Section>> GetAllSections()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(ConnectionString+"api/section/");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<ObservableCollection<Section>>(result);
            return list;
        }

        public async Task<User> GetLoggedInUser()
        {
            var userName = Settings.UserName;
            var client = new HttpClient();
            var json = await client.GetStringAsync(ConnectionString+"api/user/getbyusername/" + userName + "/");
            var user = JsonConvert.DeserializeObject<User>(json);
            return user;
        }

        public async Task<Group> GetGroup(int id)
        {
            var client = new HttpClient();
            var json = await client.GetStringAsync(ConnectionString + "api/Group/" + id.ToString() + "/");
            var group = JsonConvert.DeserializeObject<Group>(json);
            return group;
        }
        
        public async Task<User> GetSingelUser(string id)
        { 
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Settings.AccessToken);
            var json = await client.GetStringAsync(ConnectionString+"api/getusername/" + id);
            var user = JsonConvert.DeserializeObject<User>(json);
            return user;
        }
 
        public async Task<bool> CreateEvent(string tile, string location, DateTime date, string desc, string senderId)
        {
            var client = new HttpClient();
             var model = new Event()
            {
                Title = tile,
                Location = location,
                TimeForEvent = date,
                Description = desc,
                Text = desc,
                SenderId = senderId
            };
            var json = JsonConvert.SerializeObject(model);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(ConnectionString+"api/Event/AddEvent/", content);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> CreateGroup(Group group)
        {
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(group);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(ConnectionString+"api/Group/AddGroup", content);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> AddUserToNewsPostViews(int postId, string userName)
        {
            var client = new HttpClient();
            var response = await client.PostAsync(ConnectionString + "api/NewsPost/AddUserToNewsPostViewed/" + postId + "/" + userName + "/", null);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> AddUserToGroupPostViews(int postId, string userName)
        {
            var client = new HttpClient();
            var response = await client.PostAsync(ConnectionString + "api/GroupPost/AddUserToGroupPostViewed/" + postId + "/" + userName + "/", null);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> CreateNewsPost(NewsPost post)
        {
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(post);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(ConnectionString+ "api/NewsPost/AddNewsPost/", content);

            return response.IsSuccessStatusCode;
        }

        public async Task<ObservableCollection<NewsPost>> GetAllNewsPosts()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(ConnectionString+"api/newspost");
            var success = response.IsSuccessStatusCode;
            if (success)
            {
                var result = await response.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<ObservableCollection<NewsPost>>(result);
                return list;
            }
            else
            {
                var list = new ObservableCollection<NewsPost>();
                return list;
            }
        }
        
        public async Task<ObservableCollection<Group>> GetAllGroups()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(ConnectionString+"api/group");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<ObservableCollection<Group>>(result);
            return list;
        }
        
        public async Task<ObservableCollection<Event>> GetAllEvents()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(ConnectionString+"api/Event");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<ObservableCollection<Event>>(result);
            return list;
        }
    }
}
