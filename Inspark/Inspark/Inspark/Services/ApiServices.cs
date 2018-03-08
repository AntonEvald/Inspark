using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
namespace Inspark.Services
{
    public class ApiServices
    {

        public async Task<bool> RegisterAsync(string role, string email,string password)
        {
            var client = new HttpClient();
            var model = new Models.User
            {
                Email = email,
                UserName = email,
                Password = password,
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

    }
}
