using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace FrontToBack.Extensions
{
    public static class Extensions
    {
        public static bool isImage(this IFormFile file)
        {
            return file.ContentType.Contains("image");
        }

        public static bool isImageSized(this IFormFile file, int kb)
        {
            return file.Length / 1024 > kb;
        }

        public static async Task<string> SaveImage(this IFormFile file, IWebHostEnvironment env, string folder)
        {
            string path = env.WebRootPath;
            string fileName = Guid.NewGuid().ToString() + file.FileName;
            string result = Path.Combine(path, folder, fileName);
            
            using (FileStream stream = new FileStream(result, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return fileName;
        }
        
    }
    
}