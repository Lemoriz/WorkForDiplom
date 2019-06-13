namespace DiplomApi.Repositories.DownloadFile
{
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using Microsoft.Extensions.Configuration;
    using Dapper;
    using Models;
    using DiplomApi.Classes;
    using System.IO;
    using Microsoft.AspNetCore.Http;
    using System.Net;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    public class UploadFileRepository : ControllerBase, IDownloadFileRepository
    {
        private readonly IConfiguration _config;

        public UploadFileRepository(IConfiguration config)
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
        /// <param name="employeeId">ID сотрудника</param>
        /// <returns></returns>
        public async Task<IActionResult> GetByID(int documentId)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT DocumentID, [Path], [Hash] FROM Document WHERE [DocumentID] = @DocumentID";
                IEnumerable<Document> result = conn.Query<Document>(sQuery, new { DocumentId = documentId });

                Document document = result.FirstOrDefault();

                FileStream fileStream = new FileStream(document.Path, FileMode.Open, FileAccess.Read);
               // Stream stream = await File.ReadAllLines() { { __get_stream_based_on_id_here__} }

                return File(fileStream, "document/docx", "myfile.docx");

              //  return null;
            }



            //if (stream == null)
            //    return NotFound();


        }
    }
}
