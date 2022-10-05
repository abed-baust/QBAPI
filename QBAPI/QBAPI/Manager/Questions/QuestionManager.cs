using CB.Utility.Pagination;
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
            var ques = _context.QuestionModel
                     .Select(_ => new GetQuestionDtos
                     {
                         Department = _.Department,
                         Semister = _.Semister,
                         Level = _.Level,
                         QuestionURL = _.QuestionURL,
                     }).ToList();

            if (request.Department != null)
            {
                ques = ques.Where(x => x.Department == request.Department).ToList();
               
            }

            if (request.Semister != null)
            {
                ques = ques.Where(x => x.Semister == request.Semister).ToList();

            }
            if(request.Level != null)
            {
                ques = ques.Where(x => x.Level == request.Level).ToList();

            }

            return ques.ApplyPagination(request.PagingOptions).ToList();
        }
    }
}
