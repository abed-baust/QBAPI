using CB.Utility.Pagination;

namespace QBAPI.DTOs.QuestionDtos
{
    public class QuestionSearchingDto
    {
        public string? Department { get; set; }
        public string? Semister { get; set; }
        public string? Level { get; set; }
        public PagingOptions PagingOptions { get; set; }
    }
}
