namespace DiplomApi.Repositories.SendDocumentForApproval
{
    using System.Threading.Tasks;
    using DiplomApi.Classes;
    using DiplomApi.Models;

    /// <summary>
    /// Интерфейс для AuthorizInfo.
    /// </summary>
    public interface ISendDocumentForApprovalRepository
    {
        Task AddDocumentHistory(ActionHistory actionHistory);
    }
}
