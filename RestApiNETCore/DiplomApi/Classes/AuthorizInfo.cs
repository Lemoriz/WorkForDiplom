namespace DiplomApi.Classes
{
    public partial class AuthorizInfo
    {
        public AuthorizInfo()
        {

        }

        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public string TelephoneNumber { get; set; }
        public string Email { get; set; }
        public string PositionName { get; set; }
        public string ShortDescriptionPositionName { get; set; }
        public int AccessNumber { get; set; }
        public string AccessName { get; set; }
    }
}
