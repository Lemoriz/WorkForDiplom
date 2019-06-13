namespace DiplomApi.Classes
{
    using System;
    using Microsoft.AspNetCore.Http;

    public class UploadDocInfo
    {
        public IFormCollection File { get; set; }
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public DateTime Data { get; set; }
        public string EncryptHash { get; set; }
        public string PublicKey { get; set; }
        public string DocumentID { get; set; }
        public string Path { get; set; }
    }
}
