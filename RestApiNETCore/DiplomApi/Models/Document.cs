using System;
using System.Collections.Generic;

namespace DiplomApi.Models
{
    public partial class Document
    {
        public Document()
        {
            ActionHistory = new HashSet<ActionHistory>();
            SecurityInformation = new HashSet<SecurityInformation>();
        }

        public int DocumentId { get; set; }
        public string Name { get; set; }
        public string ShortDiscription { get; set; }
        public DateTime CreationDate { get; set; }
        public string Path { get; set; }
        public string Hash { get; set; }
        public float Size { get; set; }
        public int DocumentTypeId { get; set; }

        public DocumentType DocumentType { get; set; }
        public ICollection<ActionHistory> ActionHistory { get; set; }
        public ICollection<SecurityInformation> SecurityInformation { get; set; }
    }
}
