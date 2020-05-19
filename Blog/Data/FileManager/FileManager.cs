using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace Blog.Data.FileManager
{
    public class FileManager : IFileManager
    {

        private readonly IWebHostEnvironment hostEnvironment;
      //  private string _imagePath;

        public FileManager(IWebHostEnvironment hostEnvironment)
        {
            //    _configuration = config;
            //    _imagePath = config["Path:Images"];
            this.hostEnvironment = hostEnvironment;

        }

        public FileStream ImageStream(string image)
        {
            throw new NotImplementedException();
        }



        /*   public FileStream ImageStream(string image)
           {

      //         return new FileStream(Path.Combine(_imagePath, image), FileMode.Open, FileAccess.Read);
           }
           */
        public  async Task<string> SaveImage(IFormFile image)
        {
            try
            {
                string fileName = null;
                if (image != null)
                {
                string  uploadsFolder = Path.Combine(hostEnvironment.WebRootPath, "images");
                    fileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                    string filePath = Path.Combine( uploadsFolder, fileName);
                    image.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                return fileName;
            }
            /*    if (!Directory.Exists(save_path))
                {
                    Directory.CreateDirectory(save_path);
                }
                var mime = image.FileName.Substring(image.FileName.LastIndexOf('.'));
                var fileName = $"img_{DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss")}{mime}";
          //      using (var fileStream = new FileStream(Path.Combine(save_path, fileName), FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }
                return fileName;
            }
        }
        */
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return "Error";

            }
        }
    }
}
