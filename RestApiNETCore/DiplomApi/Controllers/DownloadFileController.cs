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
    using DiplomApi.Repositories.DownloadFile;

    [Route("api/[controller]")]
    [ApiController]
    public class DownloadFileController : ControllerBase
    {
        private readonly IDownloadFileRepository _downloadFileRepository;

        public DownloadFileController(IDownloadFileRepository subdivisionRepo)
        {
            _downloadFileRepository = subdivisionRepo;
        }

        [HttpGet]
        [Route("{id}")]
        [EnableCors("MyPolicy")]
        public async Task<IActionResult> GetByID(int id)
        {
            return await _downloadFileRepository.GetByID(id);
        }
    }
}
