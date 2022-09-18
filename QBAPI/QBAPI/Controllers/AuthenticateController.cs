using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using QBAPI.AuthRoles;
using QBAPI.DataModels;
using QBAPI.DTOs;
using QBAPI.Manager.Authentication;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace QBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        private readonly IAuthentication _iAuthentication;


        public AuthenticateController(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration,
            IAuthentication authentication
            )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _iAuthentication = authentication;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var token = await _iAuthentication.Login(model);
            return Ok(token);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var token = await _iAuthentication.Register(model);
            return Ok(token);
        }

        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
        {
            var token = await _iAuthentication.RegisterAdmin(model);
            return Ok(token);
        }
    }
}