using MauiBlazorApp.Interfaces;
using MauiBlazorApp.Models;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MauiBlazorApp.Services
{
    public class AppService : IAppService
    {
        private readonly HttpClient _httpClient;

        public AppService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> AuthenticateUser(LoginModel loginModel)
        {
            string returnStr = string.Empty;

            // Serialize the loginModel only once
            var serializedStr = JsonConvert.SerializeObject(loginModel);

            var content = new StringContent(serializedStr, Encoding.UTF8, "application/json");

            // Use the same content instance for multiple requests
            var response = await _httpClient.PostAsync("api/Registration/AuthenticateUser", content);

            if (response.IsSuccessStatusCode)
            {
                returnStr = await response.Content.ReadAsStringAsync();
            }

            return returnStr;
        }
    }
}
