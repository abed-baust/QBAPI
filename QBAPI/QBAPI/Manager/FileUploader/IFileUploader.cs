using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using QBAPI.DataModels;
using QBAPI.DTOs.QuestionDtos;
using System.Threading.Tasks;

namespace QBAPI.Manager.FileUploader
{
    public interface IFileUploader
    {
        Task<QuestionModel> FileUploadAsync(QuestionDtos? questionDtos);
        Task<DeletionResult> DeleteFileAsync(string publicId);
    }
}
