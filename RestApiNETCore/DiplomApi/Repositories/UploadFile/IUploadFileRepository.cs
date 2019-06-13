namespace DiplomApi.Repositories.UploadFile
{
    using DiplomApi.Classes;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Интерфейс для UploadFileRepository.
    /// </summary>
    public interface IUploadFileRepository
    {
        IActionResult UploadFile([FromForm] AddDocInfo fileUploadViewModel);
    }
}
