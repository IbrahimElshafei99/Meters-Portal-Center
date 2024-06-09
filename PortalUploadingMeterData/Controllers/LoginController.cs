using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;
using System.Text.Json.Serialization;
using MetersCenter.Business.Interfaces;
using Newtonsoft.Json;
using MetersCenter.Data;

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
            if(ModelState.IsValid)
            {
                if (token != null)
                {
                    var handler = new JwtSecurityTokenHandler();
                    var jsonToken = handler.ReadToken(token) as JwtSecurityToken;
                    var claims = jsonToken.Claims.ToList();
                    var id = claims[2].Value;
                    var nameOfUser = claims[0].Value;

                    claims.Add(new Claim(ClaimTypes.Name, username));
                    claims.Add(new Claim("JWT", token));

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true
                    };

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);

                    TempData["Username"] = nameOfUser; // To save the username in database
                    TempData["UserId"] = id;           // To save the id in database

                    //return RedirectToAction("GetAllSupplies", "Supplies");
                    if (User.Claims.FirstOrDefault(c => c.Type.Contains("role"))?.Value == "Admin")
                    {
                        return RedirectToAction("GetAllSupplies", "Supplies");
                    }
                    else if (User.Claims.FirstOrDefault(c => c.Type.Contains("role"))?.Value == "User")
                    {
                        return RedirectToAction("UploadExcel", "Supplies");
                    }

                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                

            }
            return View();

        }

        [HttpPost]
        [ResponseCache(NoStore = true, Duration = 0)]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("AdminLogin", "Login");
        }


    }
}
