using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Options;
using QBAPI.DataModels;
using QBAPI.DBContext;
using QBAPI.DTOs.CloudinarySettings;
using QBAPI.DTOs.QuestionDtos;

namespace QBAPI.Manager.FileUploader
{
    public class FileUploader : IFileUploader
    {
        private readonly Cloudinary _cloudinary;
        private readonly ApplicationDbContext _context;

        public FileUploader(IOptions<CloudinarySettings> config, ApplicationDbContext cotext)
        {
            var acc = new Account(
                config.Value.CloudName,
                config.Value.ApiKey,
                config.Value.ApiSecret
                );
            _cloudinary = new Cloudinary(acc);
            _context = cotext;
        }

        public async Task<QuestionModel> FileUploadAsync(QuestionDtos? questionDtos)
        {
            if (questionDtos?.file?.Length > 0)
            {
                await using var stream = questionDtos.file.OpenReadStream();
                var uploadParams = new RawUploadParams()
                {  
                    File =  new FileDescription(questionDtos.file.FileName, stream),
                };
                var result = await _cloudinary.UploadAsync(uploadParams,"auto");
                var Question = new QuestionModel
                {
                    Department = questionDtos.Department,
                    Level=questionDtos.Level,
                    QuestionURL= result.SecureUrl.AbsoluteUri,
                    Semister=questionDtos.Semister
                };
                await _context.AddAsync(Question);
                var succes = await _context.SaveChangesAsync();
                if(succes>0)
                return Question;
            }
            return new QuestionModel();
           
        }

 

    public async Task<DeletionResult> DeleteFileAsync(string publicId)
        {
            var deleteParams = new DeletionParams(publicId);
            var result = await _cloudinary.DestroyAsync(deleteParams);
            return result;
        }
    }
}

