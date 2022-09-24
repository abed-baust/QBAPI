using Microsoft.AspNetCore.Mvc;
using QBAPI.DataModels;
using QBAPI.DTOs;

namespace QBAPI.Manager.Authentication
{
    public interface IAuthentication
    {
        Task<TokenDto> Login([FromBody] LoginModel model);
        Task<Response> RegisterStudent([FromBody] RegisterModel model);
        Task<Response> RegisterAdmin([FromBody] RegisterModel model);
        Task<Response> RegisterTeacher([FromBody] RegisterModel model);
        Task<Response> RegisterUploader([FromBody] RegisterModel model);
    }
}
