namespace DiplomApi
{
    public class MetaInfo
    {
        public static string _connectionString = "Server=DESKTOP-Q31V8AK;Database=testDiplomDatabase;Trusted_Connection=True;";//Строка подключения к БД
        public static string _filePath = @"C:\Users\Ramil\Desktop\DiplomJob\RestApiNETCore\";//Путь для хранения файлов
    }
}
//Scaffold-DbContext “Server=DESKTOP-Q31V8AK;Database=testDiplomDatabase;Trusted_Connection=True;” Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -force // обновить модели бд