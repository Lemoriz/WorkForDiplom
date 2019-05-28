namespace DiplomApi.Classes
{
    public class Enums
    {
        public enum Action
        {
            SendForApproval = 1,
            Approved = 2,
            Rejected = 3,
            AddFileInDB = 4
        }

        public enum ActionsStaus
        {
            Norm = 1,
            Fina = 2,
            VoobseNistak = 3,
            XZ = 4
        }

        public enum DocumentType
        {
            txt = 1,
            docx = 2,
            pdf = 3,
            xls = 4
        }
    }
}
