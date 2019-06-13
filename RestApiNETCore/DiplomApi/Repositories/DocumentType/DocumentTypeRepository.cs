namespace DiplomApi.Repositories.DocumentType
{
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Configuration;
    using Dapper;
    using Models;
    using DevOne.Security.Cryptography.BCrypt;

    /// <summary>
    /// Репозиторий для работы с Employee.
    /// </summary>
    public class DocumentTypeRepository : IDocumentTypeRepository
    {
        private readonly IConfiguration _config;

        public DocumentTypeRepository(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(MetaInfo._connectionString);
            }
        }

        /// <summary>
        /// Получение сотрудников по id.
        /// </summary>
        /// <param name="documentTypeId">ID сотрудника</param>
        /// <returns></returns>
        public async Task<DocumentType> GetByID(int documentTypeId)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT DocumentTypeID, Name, ShortDescription FROM DocumentType WHERE DocumentTypeID = @DocumentTypeID";
                IEnumerable<DocumentType> result = await conn.QueryAsync<DocumentType>(sQuery, new { DocumentTypeId = documentTypeId });
                return result.FirstOrDefault();
            }
        }

        /// <summary>
        /// Получеине всех сотрудников.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DocumentType>> GetAll()
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT * FROM DocumentType";
                IEnumerable<DocumentType> result = await conn.QueryAsync<DocumentType>(sQuery);
                return result;
            }
        }
    }
}