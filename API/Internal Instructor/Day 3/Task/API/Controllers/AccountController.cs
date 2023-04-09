using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using API.DTOs;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;

        public AccountController(UserManager<AppUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegisterDTO register)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser()
                {
                    UserName = register.Email,
                    Email = register.Email,
                    Name = register.Name
                };
                var res = await _userManager.CreateAsync(user, register.Password);

                if(res.Succeeded) return Ok();

                return BadRequest(JsonConvert.SerializeObject(res.Errors));

            }

            return BadRequest(ModelState);
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginDTO login)
        {
            if (ModelState.IsValid)
            {
                var usr = await _userManager.FindByEmailAsync(login.Email);

                if (usr is null) return Unauthorized("Wrong email");

                var res = await _userManager.CheckPasswordAsync(usr, login.Password);

                if(!res) return Unauthorized("Wrong password");

                var claims = new List<Claim>()
                {
                    new(ClaimTypes.NameIdentifier, usr.Id),
                    new(ClaimTypes.Name, usr.Name),
                    new(ClaimTypes.Email, usr.Email??""),
                    new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]??"123"));

                JwtSecurityToken token = new(
                    issuer: _configuration["JWT:Issuer"],
                    audience: _configuration["JWT:Audience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: claims,
                    signingCredentials: new(key, SecurityAlgorithms.HmacSha256)
                );

                return Ok(
                    JsonConvert.SerializeObject(
                        new
                        {
                            Token = new JwtSecurityTokenHandler().WriteToken(token),
                            Expiration = token.ValidTo
                        }));
            }

            return BadRequest(ModelState);
        }
    }
}
