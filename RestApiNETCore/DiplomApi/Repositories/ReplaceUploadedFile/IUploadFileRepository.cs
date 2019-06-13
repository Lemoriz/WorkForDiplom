namespace DiplomApi.Repositories.ReplaceUploadedFile
{
    using DiplomApi.Classes;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Интерфейс для UploadFileRepository.
    /// </summary>
    public interface IReplaceUploadedFileRepository
    {
        IActionResult ReplaceUploadedFile([FromForm] UploadDocInfo fileUploadViewModel);
    }
}
