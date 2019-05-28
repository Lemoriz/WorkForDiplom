namespace DiplomApi.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Mvc;
    using DiplomApi.Repositories.UploadFile;
    using DiplomApi.Classes;
    using Microsoft.AspNetCore.Http;
    using System.Net.Http;
    using Microsoft.AspNetCore.Authorization;
    using System.Net.Http.Formatting;
    using System.Net;
    using Newtonsoft.Json.Linq;

    [Route("api/[controller]")]
    [ApiController]
    public class UploadFileController : ControllerBase
    {
        private readonly IUploadFileRepository _uploadFileRepository;

        public UploadFileController(IUploadFileRepository subdivisionRepo)
        {
            _uploadFileRepository = subdivisionRepo;
        }

        [HttpPost]
        [EnableCors("MyPolicy")]
        public IActionResult Post([FromForm] AddDocInfo fileUploadViewModel)
        {
            if (fileUploadViewModel.File.Files.Count > 0)
            {
                if (fileUploadViewModel.File.Files[0].Length != 0)
                {
                    return _uploadFileRepository.UploadFile(fileUploadViewModel);
                }                
            }
            return StatusCode((int)HttpStatusCode.NoContent);
        }
    }
}
