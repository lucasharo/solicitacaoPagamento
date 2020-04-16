using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class UploadController : Controller
    {
        private IHostingEnvironment _environment;

        public UploadController(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        [HttpPost("UploadFiles")]
        public async Task<IActionResult> PostProfilePicture(IFormFile file)
        {
            try
            {
                var uploads = Path.Combine(_environment.WebRootPath, "uploads");

                if (file.Length > 0)
                {
                    using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                }
            }
            catch (Exception)
            {

            }

            return Json("");
        }
    }
}
