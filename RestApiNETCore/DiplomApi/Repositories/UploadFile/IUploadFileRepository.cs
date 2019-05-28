namespace DiplomApi.Repositories.UploadFile
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Formatting;
    using System.Threading.Tasks;
    using DiplomApi.Classes;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Интерфейс для UploadFileRepository.
    /// </summary>
    public interface IUploadFileRepository
    {
        IActionResult UploadFile([FromForm] AddDocInfo fileUploadViewModel);
    }
}
