using Microsoft.AspNetCore.Mvc;
using QBAPI.DataModels;
using QBAPI.DTOs;

namespace QBAPI.Manager.Authentication
{
    public interface IAuthentication
    {
        Task<TokenDto> Login([FromBody] LoginModel model);
        Task<Response> Register([FromBody] RegisterModel model);
        Task<Response> RegisterAdmin([FromBody] RegisterModel model);
    }
}
