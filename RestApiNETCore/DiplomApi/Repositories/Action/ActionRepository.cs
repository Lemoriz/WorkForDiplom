namespace DiplomApi.Repositories.Action
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
    public class ActionRepository : IActionRepository
    {
        private readonly IConfiguration _config;

        public ActionRepository(IConfiguration config)
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
        public async Task<IEnumerable<Models.Action>> GetAll()
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT * FROM Action";
                IEnumerable<Models.Action> result = await conn.QueryAsync<Models.Action>(sQuery);
                return result;
            }
        }
    }
}