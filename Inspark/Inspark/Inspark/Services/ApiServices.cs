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
        private byte[] pic;

        public async Task<bool> RegisterAsync(string role, string email,string password)
        {
            
#if __ANDROID__
                Uri fileuri = Uri.parse("android.resource://drawable"+ R.drawable.DefaultPic);
                var path = new File(fileuri.getPath());
                pic = File.ReadAllBytes(path);

#endif

            
            var client = new HttpClient();
            var model = new User
            {
                UserName = email,
                Password = password,
                Email = email,
                Role = role,
                ProfilePicture = pic
                //FirstName = firstname,
                //LastName = lastname,
                //PhoneNumber = phonenumber

            };

            var json = JsonConvert.SerializeObject(model);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://insparkwebapi.azurewebsites.net/api/user",content);

            return response.IsSuccessStatusCode;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("https://insparkwebapi.azurewebsites.net/api/user");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            Debug.WriteLine(json);
            var list = JsonConvert.DeserializeObject<List<User>>(json);
            return list;
        }

    }
}
