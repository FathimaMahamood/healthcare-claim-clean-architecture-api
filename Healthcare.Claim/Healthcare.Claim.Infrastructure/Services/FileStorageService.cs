using HealthcareClaim.Application.Interfaces;
using HealthcareClaim.Infrastructure.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;


namespace HealthcareClaim.Infrastructure.Services
{
    public class FileStorageService : IFileStorageService
    {
        private readonly string _uploadPath;

        public FileStorageService(IOptions<FileStorageOptions> options)
        {
            _uploadPath = options.Value.UploadPath;

            // Ensure directory exists
            if (!Directory.Exists(_uploadPath))
                Directory.CreateDirectory(_uploadPath);
        }

        public async Task<string> SaveFileAsync(IFormFile file)
        {
            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(_uploadPath, fileName);

            
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return $"uploads/{fileName}"; // return relative path
        }
    }

}
