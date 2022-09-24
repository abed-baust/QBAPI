using QBAPI.DataModels;
using QBAPI.DTOs.QuestionDtos;

namespace QBAPI.Manager.Questions
{
    public interface IQuestionManager
    {
        Task<List<GetQuestionDtos>> GetQuestionsList();
        Task<List<GetQuestionDtos>> GetQuestionsBy(QuestionSearchingDto request);
    }
}
