namespace DiplomApi.Repositories.SendDocumentForApproval
{
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Configuration;
    using Dapper;
    using Models;
    using DiplomApi.Classes;
    using DevOne.Security.Cryptography.BCrypt;
    using System;

    public class SendDocumentForApprovalRepository : ISendDocumentForApprovalRepository
    {
        private readonly IConfiguration _config;

        public SendDocumentForApprovalRepository(IConfiguration config)
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
        /// Получение пользователя с комбинацией логина, пароля, позиции и уровня доступа.
        /// </summary>
        /// <param email="employeeId">email сотрудника</param>
        /// <param password="employeeId">пароль сотрудника</param>
        /// <returns></returns>
        public async Task AddDocumentHistory(ActionHistory actionHistory)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = @"INSERT INTO ActionHistory(Name, ActionStatusID, DocumentID, EmployeeID, ActionID) VALUES (@Name, @ActionStatusID, @DocumentID, @EmployeeID, @ActionID)";
                var result = await conn.ExecuteAsync(sQuery,
                    new ActionHistory
                    {
                        Name = actionHistory.ActionId == 1? "Документ отправлен на согласование" : "Документ согласован",
                        ActionStatusId = 1,
                        DocumentId = actionHistory.DocumentId,
                        EmployeeId = actionHistory.EmployeeId,
                        ActionId = actionHistory.ActionId
                    });
            }

        }
    }
}
