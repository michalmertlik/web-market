using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace market.Services
{
	public class ImageService
	{
        IWebHostEnvironment hostingEnvironment;
        public ImageService(IWebHostEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }

        public (bool success, Exception exception) SaveImage(string filename, Stream imageStream)
        {
            try
            {
                var path = Path.Combine(hostingEnvironment.ContentRootPath, "wwwroot/avatars");
                Directory.CreateDirectory(path);
                path = Path.Combine(path, filename);

                using (var fileStream = new FileStream(path, FileMode.Create))
                    imageStream.CopyTo(fileStream);
            }
            catch (Exception ex) { return (false, ex); }

            return (true, null);
        }
    }
}
