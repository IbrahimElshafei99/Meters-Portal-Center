using MetersCenter.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MetersCenter.Business.Services
{
    public class AuthService : IAuthService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AuthService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> GetToken(string username, string password)
        {
            var client = _httpClientFactory.CreateClient();
            var loginModel = new {username = username, password = password};

            HttpResponseMessage response = await client.PostAsJsonAsync("https://localhost:44310/api/Authenticate/Login", loginModel);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<TokenResponse>();
                return result.Token;
            }

            return null;
        }
    }

    public class TokenResponse
    {
        public string? Token { get; set; }
    }
}
