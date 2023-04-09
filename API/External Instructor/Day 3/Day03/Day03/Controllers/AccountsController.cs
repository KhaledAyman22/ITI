using Day03.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Day03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;

        public AccountsController(IConfiguration configuration,
            UserManager<User> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }

        [HttpPost("register/admin")]
        public async Task<ActionResult> RegisterAdmin([FromBody] RegisterDto registerDto)
        {
            var user = new User
            {
                UserName = registerDto.Username,
                Email = registerDto.Email,
                Age = registerDto.Age
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (result.Succeeded)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Role, "Admin"),
                    new Claim(ClaimTypes.NameIdentifier, user.Id)
                };

                await _userManager.AddClaimsAsync(user, claims);

                return NoContent();
            }
            return BadRequest(result.Errors);
        }

        [HttpPost("register/user")]
        public async Task<ActionResult> RegisterUser([FromBody] RegisterDto registerDto)
        {
            var user = new User
            {
                UserName = registerDto.Username,
                Email = registerDto.Email,
                Age = registerDto.Age
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (result.Succeeded)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Role, "User"),
                    new Claim(ClaimTypes.NameIdentifier, user.Id)
                };

                await _userManager.AddClaimsAsync(user, claims);

                return NoContent();
            }
            return BadRequest(result.Errors);
        }

        [HttpPost("login")]
        public async Task<ActionResult<TokenDto>> Login(LoginDto credentials)
        {
            var user = await _userManager.FindByNameAsync(credentials.Username);
            if (user == null)
            {
                return NotFound();
            }

            var isAuthenitcated = await _userManager.CheckPasswordAsync(user, credentials.Password);

            if (isAuthenitcated)
            {
                var claimsList = await _userManager.GetClaimsAsync(user);

                var secretKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]??""));

                var siginingCreedentials = new SigningCredentials(secretKey,
                    SecurityAlgorithms.HmacSha256Signature);

                var expiry = DateTime.Now.AddDays(1);

                var token = new JwtSecurityToken(
                    claims: claimsList,
                    expires: expiry,
                    signingCredentials: siginingCreedentials);

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenString = tokenHandler.WriteToken(token);

                return new TokenDto(tokenString, expiry);
            }
            return Unauthorized();
        }
    }
}
