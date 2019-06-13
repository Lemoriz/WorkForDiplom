namespace DiplomApi.Repositories.ReplaceUploadedFile
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

    public class ReplaceUploadedFileRepository : ControllerBase, IReplaceUploadedFileRepository
    {
        private readonly IConfiguration _config;

        public ReplaceUploadedFileRepository(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection Connection
        {
            get { return new SqlConnection(MetaInfo._connectionString); }
        }

        public string GetOriginalFilePath(string filePath, string fileType)
        {
            int copyNumber = 1;

            while (System.IO.File.Exists(filePath))
            {
                if (!filePath.Contains(" - Copy ("))
                {
                    string part = filePath.Substring(0, filePath.LastIndexOf(fileType));

                    filePath = part + $" - Copy ({copyNumber})" + fileType;
                }
                else
                {
                    filePath = filePath.Replace($" - Copy ({copyNumber})", $" - Copy ({copyNumber + 1})");
                    copyNumber++;
                }
            }

            return filePath;
        }

        /// <summary>
        /// Получить список типов документа.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public IEnumerable<DocumentType> GetAllDocumentType()
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT * FROM DocumentType";
                IEnumerable<DocumentType> result = conn.Query<DocumentType>(sQuery);
                return result;
            }
        }

        public void ReplaceDocumentInDatabase(Document document)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    string sQuery = @"UPDATE Document SET Name = @Name, Size = @Size, Hash = @Hash, DocumentTypeID = @DocumentTypeID WHERE DocumentID = @DocumentID";
                    var result = conn.Execute(sQuery,
                        new Document
                        {
                            DocumentId = document.DocumentId,
                            Name = document.Name,
                            ShortDiscription = document.ShortDiscription,
                            Path = document.Path,
                            Size = document.Size,
                            Hash = document.Hash,
                            DocumentTypeId = document.DocumentTypeId
                        });
                }
            }
            catch
            {
                throw new System.ArgumentException("Короч, чет не так при добавлении табличи Document в бд");
            }
        }

        /// <summary>
        /// Загрузка файла и проверка целостности
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IActionResult ReplaceUploadedFile([FromForm] UploadDocInfo model)
        {
            IFormFile file = model.File.Files[0];

            double fileSizeInKB = Math.Round((Convert.ToDouble(file.Length) / 1024), 2);
            string fileName = file.FileName;
            string filePath = MetaInfo._filePath + fileName;
            string fileType = fileName.Substring(fileName.LastIndexOf('.'), fileName.Length - fileName.LastIndexOf('.'));
            string originalFilePath = model.Path;

            DocumentType documentType = GetAllDocumentType().First(value => value.Name == fileType.Remove(0, 1));

            //Add file in folder
            using (FileStream fileStream = new FileStream(originalFilePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }

            ReplaceDocumentInDatabase(new Document
            {
                DocumentId = Convert.ToInt32(model.DocumentID),
                Name = model.Name,
                Size = float.Parse($"{fileSizeInKB}", System.Globalization.CultureInfo.InvariantCulture),
                Hash = model.EncryptHash,
                DocumentTypeId = documentType.DocumentTypeId
            });

            CheckActionHistory("Добавлен документ", new Document { Path = model.Path, Hash = model.EncryptHash, DocumentId = Convert.ToInt32(model.DocumentID) }, model.EmployeeID, Enums.Action.EditDocument);

            return StatusCode((int)HttpStatusCode.OK);
        }

        /// <summary>
        /// Проверить статус действия.
        /// </summary>
        /// <param name="nameAction"></param>
        /// <param name="document"></param>
        /// <param name="employeeID"></param>
        /// <param name="actionID"></param>
        public void CheckActionHistory(string nameAction, Document document, int employeeID, Enums.Action actionID)
        {
            if (Enums.Action.EditDocument == actionID)
            {
                List<string> input = new List<string>();

                StreamReader sr = new StreamReader(document.Path);

                while (!sr.EndOfStream)
                {
                    input.Add(sr.ReadLine());
                }

                sr.Close();

                Enums.ActionsStaus actionsStaus = document.Hash == "5as6d4as68d46sad" ? Enums.ActionsStaus.VoobseNistak : Enums.ActionsStaus.XZ;

                AddActionHistoryInDB(new ActionHistory
                {
                    Name = "Изменен документ",
                    ActionStatusId = (int)actionsStaus,
                    DocumentId = document.DocumentId,
                    EmployeeId = employeeID,
                    ActionId = (int)actionID
                });
            }
        }

        /// <summary>
        /// Добавить в БД ActionHistory.
        /// </summary>
        /// <param name="actionHistory"></param>
        public async void AddActionHistoryInDB(ActionHistory actionHistory)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    string sQuery = @"INSERT INTO ActionHistory(Name, ActionStatusID, DocumentID, EmployeeID, ActionID) VALUES (@Name, @ActionStatusID, @DocumentID, @EmployeeID, @ActionID)";
                    var result = await conn.ExecuteAsync(sQuery,
                        new ActionHistory
                        {
                            Name = actionHistory.Name,
                            ActionStatusId = actionHistory.ActionStatusId,
                            DocumentId = actionHistory.DocumentId,
                            EmployeeId = actionHistory.EmployeeId,
                            ActionId = actionHistory.ActionId,
                        });
                }
            }
            catch
            {
                throw new System.ArgumentException("Короч, чет не так при добавлении табличи Document в бд");
            }
        }
    }
}
