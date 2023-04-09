using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.AccessControl;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Day03.Dtos;

namespace Day03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EndpointsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;

        public EndpointsController(IConfiguration configuration,
            UserManager<User> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }

        [HttpGet("userinfo")]
        [Authorize(Policy = "AllowAny")]
        public async Task<ActionResult<UserInfoDto>> GetAnyUserInfo()
        {
            var user = await _userManager.GetUserAsync(User);
            
            return new UserInfoDto (user!.UserName??"", user.Email??"", user.Age);
        }

        [HttpGet("admin/info")]
        [Authorize(Policy = "AllowAdmins")]
        public ActionResult<string> GetAdminInfo()
        {
            return "This endpoint is only accessible for admin role.";
        }

        [HttpGet("user/info")]
        [Authorize(Policy = "AllowUsers")]
        public ActionResult<string> GetUserInfo()
        {
            return "This endpoint is only accessible for user role.";
        }
    }
}
