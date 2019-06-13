namespace DiplomApi.Repositories.ActionHistory
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
    public class ActionHistoryRepository : IActionHistoryRepository
    {
        private readonly IConfiguration _config;

        public ActionHistoryRepository(IConfiguration config)
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
        /// Получеине всех сотрудников.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ActionHistory>> GetAll()
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT * FROM ActionHistory";
                IEnumerable<ActionHistory> result = await conn.QueryAsync<ActionHistory>(sQuery);
                return result;
            }
        }
    }
}