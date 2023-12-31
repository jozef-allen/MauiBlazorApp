﻿using MauiBlazorApp.Interfaces;
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

            _httpClient.Timeout = TimeSpan.FromSeconds(10);
        }

        //public async Task<string> AuthenticateUser(LoginModel loginModel)
        //{
        //    string returnStr = string.Empty;

        //    var serializedStr = JsonConvert.SerializeObject(loginModel);

        //    var content = new StringContent(serializedStr, Encoding.UTF8, "application/json");

        //    var response = await _httpClient.PostAsync("api/Registration/AuthenticateUser", content);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        returnStr = await response.Content.ReadAsStringAsync();
        //    }

        //    return returnStr;
        //}


        public async Task<AuthenticationResponse> AuthenticateUser(LoginModel loginModel)
        {
            var returnResponse = new AuthenticationResponse();

            try
            {
                var serializedStr = JsonConvert.SerializeObject(loginModel);
                var content = new StringContent(serializedStr, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("api/Registration/AuthenticateUser", content);

                if (response.IsSuccessStatusCode)
                {
                    returnResponse.IsSuccess = true;
                    returnResponse.Token = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    returnResponse.ErrorMessage = $"Error: {response.StatusCode}";
                }
            }
            catch (TaskCanceledException)
            {
                returnResponse.ErrorMessage = "The request timed out. Please check connection to the API.";
            }

            return returnResponse;
        }




        public async Task<(bool IsSuccess, string ErrorMessage)> RegisterUser(RegistrationModel registerUser)
        {
            string errorMessage = string.Empty;
            bool isSuccess = false;
            
            var serializedStr = JsonConvert.SerializeObject(registerUser);
            var content = new StringContent(serializedStr, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/Registration/RegisterUser", content);
            if (response.IsSuccessStatusCode)
            {
                isSuccess = true;
            } else
            {
                errorMessage= await response.Content.ReadAsStringAsync();
            }
            return (isSuccess, errorMessage);
        }
    }
}
