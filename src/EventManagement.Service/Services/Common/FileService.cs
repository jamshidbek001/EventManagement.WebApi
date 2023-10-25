using EventManagement.Service.Interfaces.Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace EventManagement.Service.Services.Common;

public class FileService : IFileService
{
    private readonly string MEDIA = "media";
    private readonly string IMAGES = "images";
    private readonly string ROOTPATH;

    public FileService(IWebHostEnvironment env)
    {
        ROOTPATH = env.WebRootPath;
    }

    public Task<bool> DeleteImageAsync(string subpath)
    {
        throw new NotImplementedException();
    }

    public Task<string> UploadImageAsync(IFormFile image)
    {
        throw new NotImplementedException();
    }
}