namespace DiplomApi.Classes
{
    using Microsoft.AspNetCore.Http;
    using System;

    public class AddDocInfo
    {
        public IFormCollection File { get; set; }
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public DateTime Data { get; set; }
        public string EncryptHash { get; set; }
        public string PublicKey { get; set; }
    }
}
