using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomApi.Classes
{
    public class DocumentWithChoice
    {
        public int DocumentId { get; set; }
        public string Name { get; set; }
        public string ShortDiscription { get; set; }
        public DateTime CreationDate { get; set; }
        public string Path { get; set; }
        public string Hash { get; set; }
        public float Size { get; set; }
        public int DocumentTypeId { get; set; }
        public bool GetNoSendForApproval { get; set; }
    }
}
