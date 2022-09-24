using QBAPI.DBContext;
using QBAPI.DTOs.QuestionDtos;

namespace QBAPI.Manager.Questions
{
    public class QuestionManager : IQuestionManager
    {
        private readonly ApplicationDbContext _context;

        public QuestionManager(ApplicationDbContext cotext)
        {
            _context = cotext;
        }

        public async Task<List<GetQuestionDtos>> GetQuestionsList()
        {
            var Questions = _context.QuestionModel
             .Select(_ => new GetQuestionDtos
             {
              Department = _.Department,
              Semister = _.Semister,
              Level = _.Level,
              QuestionURL = _.QuestionURL,
             }).ToList();


            return await Task.FromResult(Questions);
        }        
        
        public async Task<List<GetQuestionDtos>> GetQuestionsBy(QuestionSearchingDto request)
        {
            if (request.Department != null && request.Semister!=null && request.Level == null)
            {
                var QuestionsDeptSem = _context.QuestionModel
                     .Where(_ =>
                         _.Department.ToLower() == request.Department.ToLower() &&
                         _.Semister.ToLower() == request.Semister.ToLower()
                     )
                     .Select(_ => new GetQuestionDtos
                     {
                         Department = _.Department,
                         Semister = _.Semister,
                         Level = _.Level,
                         QuestionURL = _.QuestionURL,
                     }).ToList();
                return await Task.FromResult(QuestionsDeptSem);
            }

            if (request.Department != null && request.Semister != null && request.Level!=null)
            {
                var QuestionsAll = _context.QuestionModel
                 .Where(_ =>
                     _.Department.ToLower() == request.Department.ToLower() &&
                     _.Semister.ToLower() == request.Semister.ToLower() &&
                     _.Level.ToLower() == request.Level.ToLower()

                 )
                 .Select(_ => new GetQuestionDtos
                 {
                     Department = _.Department,
                     Semister = _.Semister,
                     Level = _.Level,
                     QuestionURL = _.QuestionURL,
                 }).ToList();
                return await Task.FromResult(QuestionsAll);
            }

            return null;
        }
    }
}
