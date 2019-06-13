namespace DiplomApi.Repositories.Document
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    /// <summary>
    /// Интерфейс для Document.
    /// </summary>
    public interface IDocumentRepository
    {
        Task<IEnumerable<Document>> GetByID(string id);
        Task<IEnumerable<Document>> GetAll();
        Task AddDocument(Document document);
    }
}