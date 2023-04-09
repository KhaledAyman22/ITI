using API.DTOs;
using Desktop;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Web.Controllers
{
    public class AuthorizationController : Controller
    {
        RequestMaker requestMaker;

        public AuthorizationController()
        {
            requestMaker = new("Account");
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            if (ModelState.IsValid)
            {
                var res = await requestMaker.MakeRequest(loginDTO, typeof(LoginDTO), HttpMethod.Post, "Login", false);

                if (res.IsSuccessStatusCode)
                {
                    string contetnt = await res.Content.ReadAsStringAsync();
                    var JWT = JsonSerializer.Deserialize(contetnt, typeof(JWTToken));

                    CurrentJWT.Token = ((JWTToken)JWT).Token;
                    CurrentJWT.Expiration = ((JWTToken)JWT).Expiration;

                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            if (ModelState.IsValid)
            {
                var res = await requestMaker.MakeRequest(registerDTO, typeof(RegisterDTO), HttpMethod.Post, "Register", false);

                if (res.IsSuccessStatusCode)
                {
                    string contetnt = await res.Content.ReadAsStringAsync();
                    var JWT = JsonSerializer.Deserialize(contetnt, typeof(JWTToken));

                    CurrentJWT.Token = ((JWTToken)JWT).Token;
                    CurrentJWT.Expiration = ((JWTToken)JWT).Expiration;

                    return RedirectToAction("Login");
                }
            }

            return View();
        }
    }
}
