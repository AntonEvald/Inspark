using System;
using System.Threading.Tasks;
namespace Inspark.Services
{
    public class ApiServices
    {

        public async Task<bool> RegisterAsync(string email,string password,string confirmpassword,string firstname,string lastname,int phonenumber)
        {
            //var client = new HttpClient();
            var model = new Models.User
            {
                Email = email,
                UserName = email,
                Password = password,
                FirstName = firstname,
                LastName = lastname,
                PhoneNumber = phonenumber

            };

            //var json = JsonConvert.SerializeObject(model);
            //HttpContent content = new StringContent(json);
            //var response = await client.PostAsync("url to webservice",content,);

            return true; //response.isSuccessStatusCode;
        }

    }
}
