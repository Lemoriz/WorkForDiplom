namespace DiplomApi.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Mvc;
    using DiplomApi.Classes;
    using Microsoft.AspNetCore.Http;
    using System.Net.Http;
    using Microsoft.AspNetCore.Authorization;
    using System.Net.Http.Formatting;
    using System.Net;
    using Newtonsoft.Json.Linq;
    using DiplomApi.Repositories.ReplaceUploadedFile;

    [Route("api/[controller]")]
    [ApiController]
    public class ReplaceUploadedFileController : ControllerBase
    {
        private readonly IReplaceUploadedFileRepository _replaceUploadedFileController;

        public ReplaceUploadedFileController(IReplaceUploadedFileRepository subdivisionRepo)
        {
            _replaceUploadedFileController = subdivisionRepo;
        }

        [HttpPost]
        [EnableCors("MyPolicy")]
        public IActionResult Post([FromForm] UploadDocInfo fileUploadViewModel)
        {
            if (fileUploadViewModel.File.Files.Count > 0)
            {
                if (fileUploadViewModel.File.Files[0].Length != 0)
                {
                    return _replaceUploadedFileController.ReplaceUploadedFile(fileUploadViewModel);
                }                
            }
            return StatusCode((int)HttpStatusCode.NoContent);
        }
    }
}
