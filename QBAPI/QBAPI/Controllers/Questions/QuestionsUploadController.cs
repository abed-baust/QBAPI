using CB.Utility.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QBAPI.AuthRoles;
using QBAPI.DataModels;
using QBAPI.DTOs.QuestionDtos;
using QBAPI.Manager.Authentication;
using QBAPI.Manager.FileUploader;
using QBAPI.Manager.Questions;

namespace QBAPI.Controllers.Questions
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsUploadController : ControllerBase
    {

        private readonly IFileUploader _ifileuploader;
        private readonly IQuestionManager _questionManager;


        public QuestionsUploadController(IFileUploader fileUploader, IQuestionManager questionManager)
        {
            _ifileuploader = fileUploader;
            _questionManager = questionManager;
        }

        [Authorize(Roles = UserRoles.UploaderCR + "," + UserRoles.SuperAdmin)]
        [HttpPost("uploadQuestion")]
        public async Task<ActionResult<QuestionModel>> UploadFile([FromQuery] QuestionDtos questionDtos)
        {
            var result = await _ifileuploader.FileUploadAsync(questionDtos);

            return result;
        }

        [Authorize(Roles = UserRoles.Student + "," + UserRoles.Teacher + "," + UserRoles.SuperAdmin)]
        [HttpGet("GetAllQuestions")]
        public async Task<IActionResult> GetQuestionsList()
        {
            var result = await _questionManager.GetQuestionsList();
            return Ok(result);
        }

        //[Authorize(Roles = UserRoles.Student + "," + UserRoles.Teacher + "," + UserRoles.SuperAdmin)]
        [HttpGet("GetAllQuestionsBy")]
        public async Task<IActionResult> GetQuestionsByDeptList([FromQuery] QuestionSearchingDto request, [FromQuery] PagingOptions pagingOptions)
        {
            request.PagingOptions ??= pagingOptions;
            var result = await _questionManager.GetQuestionsBy(request);
            return Ok(result);
        }        
        

    }
}
