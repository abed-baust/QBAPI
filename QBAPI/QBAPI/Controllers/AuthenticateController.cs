using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using QBAPI.AuthRoles;
using QBAPI.DataModels;
using QBAPI.DTOs;
using QBAPI.DTOs.QuestionDtos;
using QBAPI.Manager.Authentication;
using QBAPI.Manager.FileUploader;
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
        private readonly IFileUploader _ifileuploader;

        private readonly IAuthentication _iAuthentication;


        public AuthenticateController(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration,
            IAuthentication authentication,
            IFileUploader fileUploader
            )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _iAuthentication = authentication;
            _ifileuploader = fileUploader;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var token = await _iAuthentication.Login(model);
            return Ok(token);
        }

        [HttpPost]
        [Route("register-student")]
        public async Task<IActionResult> RegisterStudent([FromBody] RegisterModel model)
        {
            var token = await _iAuthentication.RegisterStudent(model);
            return Ok(token);
        }

        [HttpPost]
        [Route("registersuper-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
        {
            var token = await _iAuthentication.RegisterAdmin(model);
            return Ok(token);
        }

        [Authorize(Roles = UserRoles.SuperAdmin)]
        [HttpPost]
        [Route("registersuper-uploader")]
        public async Task<IActionResult> RegisterUploader([FromBody] RegisterModel model)
        {
            var token = await _iAuthentication.RegisterUploader(model);
            return Ok(token);
        }

        [Authorize(Roles = UserRoles.SuperAdmin)]
        [HttpPost]
        [Route("registersuper-teacher")]
        public async Task<IActionResult> RegisterTeacher([FromBody] RegisterModel model)
        {
            var token = await _iAuthentication.RegisterTeacher(model);
            return Ok(token);
        }

    }
}