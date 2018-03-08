using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
namespace Inspark.Services
{
    public class ApiServices
    {

        public async Task<bool> RegisterAsync(string role, string email,string password)
        {
            var client = new HttpClient();
            var model = new Models.User
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
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://insparkwebapi.azurewebsites.net/api/user",content);

            return response.IsSuccessStatusCode;
        }

    }
}
