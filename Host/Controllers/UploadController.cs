using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UploadController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> UploadFile( IFormFile file )
        {
            
           
            // Save the file to the server
            // (You can specify a different path or handle the file in a different way)
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files", file.FileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Ok();
        }
    }
}
