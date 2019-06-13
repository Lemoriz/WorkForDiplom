namespace DiplomApi.Repositories.Document
{
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Configuration;
    using Dapper;
    using Models;

    /// <summary>
    /// Репозиторий для работы с Document.
    /// </summary>
    public class DocumentRepository : IDocumentRepository
    {
        private readonly IConfiguration _config;

        public DocumentRepository(IConfiguration config)
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
        /// Получение документа по id.
        /// </summary>
        /// <param name="documentID">id документа</param>
        /// <returns></returns>
        public async Task<IEnumerable<Document>> GetByID(string documentID)//wantToApprove   noWantToApprove
        {
            List<string> documentsSendedForApproval = new List<string>();

            using (IDbConnection conn = Connection)
            {
                   
                string sQuery = "SELECT * FROM ActionHistory";
                IEnumerable<ActionHistory> result = await conn.QueryAsync<ActionHistory>(sQuery);

                IEnumerable<int> unicDocsID = result.Select(x => x.DocumentId).Distinct();

                foreach (int unicDocID in unicDocsID)
                {
                    var res = result.Where(x => x.DocumentId == unicDocID ).OrderByDescending(t => t.Date).FirstOrDefault();

                    if (res != null)
                    {
                        if (documentID == "wantToApprove" && res.ActionId == 1)
                            documentsSendedForApproval.Add($"'{res.DocumentId.ToString()}'");

                        if (documentID == "noWantToApprove" && res.ActionId != 1)
                            documentsSendedForApproval.Add($"'{res.DocumentId.ToString()}'");
                    }
                }
            }

            using (IDbConnection conn = Connection)
            {
                string sQuery = $"SELECT DocumentID, Name, ShortDiscription, CreationDate, Path, Hash, Size, DocumentTypeID FROM Document WHERE DocumentID IN ({string.Join(", ", documentsSendedForApproval)})";
                IEnumerable<Document> result = await conn.QueryAsync<Document>(sQuery);
                return result;

            }
        }


    /// <summary>
    /// Получение всех документов.
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<Document>> GetAll()
    {
        using (IDbConnection conn = Connection)
        {
            string sQuery = "SELECT * FROM Document";
            IEnumerable<Document> result = await conn.QueryAsync<Document>(sQuery);
            return result;
        }
    }

    /// <summary>
    /// Добавление документа.
    /// </summary>
    /// <param name="document">Документ для добавления</param>
    /// <returns></returns>
    public async Task AddDocument(Document document)
    {
        using (IDbConnection conn = Connection)
        {
            string sQuery = @"INSERT INTO Document(Name, ShortDiscription, Path, Size, DocumentTypeID) VALUES (@Name, @ShortDiscription, @Path, @Size, @DocumentTypeID)";
            var result = await conn.ExecuteAsync(sQuery,
                new Document
                {
                    Name = document.Name,
                    ShortDiscription = document.ShortDiscription,
                    Path = document.Path,
                    Size = document.Size,
                    DocumentTypeId = document.DocumentTypeId
                });
        }
    }
}
}