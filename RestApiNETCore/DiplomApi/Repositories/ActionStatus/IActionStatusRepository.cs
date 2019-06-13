namespace DiplomApi.Repositories.ActionStatus
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    /// <summary>
    /// Интерфейс для Employee.
    /// </summary>
    public interface IActionStatusRepository
    {
        Task<IEnumerable<ActionStatus>> GetAll();
    }
}