namespace DiplomApi.Repositories.DocumentType
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    /// <summary>
    /// Интерфейс для Employee.
    /// </summary>
    public interface IDocumentTypeRepository
    {
        Task<DocumentType> GetByID(int id);
        Task<IEnumerable<DocumentType>> GetAll();
    }
}