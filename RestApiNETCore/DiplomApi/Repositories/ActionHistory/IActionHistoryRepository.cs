namespace DiplomApi.Repositories.ActionHistory
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    /// <summary>
    /// Интерфейс для Employee.
    /// </summary>
    public interface IActionHistoryRepository
    {
        Task<IEnumerable<ActionHistory>> GetAll();
    }
}