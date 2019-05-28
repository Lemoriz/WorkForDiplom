namespace DiplomApi.Repositories.AuthorizInfo
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

    public class AuthorizInfoRepository : IAuthorizInfoRepository
    {
        private readonly IConfiguration _config;

        public AuthorizInfoRepository(IConfiguration config)
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
        public async Task<AuthorizInfo> Get(string email, string password)
        {
            using (IDbConnection conn = Connection)
            {
                string employeeStringQuery = "SELECT EmployeeId, Name, Surname, MiddleName, TelephoneNumber, Password, Email, PositionID FROM Employee WHERE Email = @Email";
                IEnumerable<Employee> employeeResult = await conn.QueryAsync<Employee>(employeeStringQuery, new { Email = email });
                try
                {
                    if (BCryptHelper.CheckPassword(password, employeeResult.FirstOrDefault().Password))
                    {
                        string positionStringQuery = "SELECT Name, ShortDescription, AccessLevelId FROM Position WHERE PositionID = @PositionID";
                        IEnumerable<Position> positionResult = await conn.QueryAsync<Position>(positionStringQuery, new { PositionID = employeeResult.FirstOrDefault().PositionId });

                        string accessLevelStringQuery = "SELECT Number, Name FROM AccessLevel WHERE AccessLevelID = @AccessLevelID";
                        IEnumerable<AccessLevel> accessLevelresult = await conn.QueryAsync<AccessLevel>(accessLevelStringQuery, new { AccessLevelID = positionResult.FirstOrDefault().AccessLevelId });

                        return new AuthorizInfo
                        {
                            EmployeeId = employeeResult.FirstOrDefault().EmployeeId,
                            Name = employeeResult.FirstOrDefault().Name,
                            Surname = employeeResult.FirstOrDefault().Surname,
                            MiddleName = employeeResult.FirstOrDefault().MiddleName,
                            TelephoneNumber = employeeResult.FirstOrDefault().TelephoneNumber,
                            Email = employeeResult.FirstOrDefault().Email,
                            PositionName = positionResult.FirstOrDefault().Name,
                            ShortDescriptionPositionName = positionResult.FirstOrDefault().ShortDescription,
                            AccessName = accessLevelresult.FirstOrDefault().Name,
                            AccessNumber = accessLevelresult.FirstOrDefault().Number
                        };
                    }
                }
                catch { }

                return null;
            }
        }
    }
}
