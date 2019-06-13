namespace DiplomApi.Repositories.DownloadFile
{
    using DiplomApi.Classes;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public interface IDownloadFileRepository
    {
        Task<IActionResult> GetByID(int id);
    }
}