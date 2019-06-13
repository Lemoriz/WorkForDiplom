namespace DiplomApi.Repositories.Action
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    /// <summary>
    /// Интерфейс для Employee.
    /// </summary>
    public interface IActionRepository
    {
        Task<IEnumerable<Models.Action>> GetAll();
    }
}