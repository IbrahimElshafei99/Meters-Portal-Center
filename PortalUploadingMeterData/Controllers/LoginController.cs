using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;
using System.Text.Json.Serialization;
using MetersCenter.Business.Interfaces;
using Newtonsoft.Json;

namespace PortalUploadingMeterData.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IHttpClientFactory _httpClientFactory;

        public LoginController(IAuthService authService, IHttpClientFactory httpClientFactory)
        {
            _authService = authService;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AdminLogin(string username, string pass)
        {
            var token = await _authService.GetToken(username, pass);

            if (token != null)
            {
                //TempData["adminUsername"] = username; // If we want to save the username in database
                return RedirectToAction("UploadExcel", "Supplies");
            }
            return View();

            /*Response.Cookies.Append("token", token);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44310/");

                HttpResponseMessage response = await client.GetAsync("Authenticate/Login");

                if (response.IsSuccessStatusCode)
                {
                    var token = await response.Content.ReadFromJsonAsync<JsonSerializerContext>();
                    var jsonToken = new JwtSecurityTokenHandler().ReadToken(token) as JwtSecurityToken;
                    var username = jsonToken.Claims.FirstOrDefault(m => m.Type == ClaimTypes.Name).Value;

                    if (username == user.Name)
                    {
                        var claims = new Claim[]
                        {
                            new Claim(ClaimTypes.Name, user.Name),
                        };
                        var claimsIdentity = new ClaimsIdentity(claims);
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                    }
                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }
            }
            */
        }


    }
}
