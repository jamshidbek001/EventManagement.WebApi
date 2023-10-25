using Microsoft.AspNetCore.Http;

namespace EventManagement.Service.Interfaces.Common
{
    public interface IFileService
    {
        public Task<string> UploadImageAsync(IFormFile image);

        public Task<bool> DeleteImageAsync(string subpath);
    }
}