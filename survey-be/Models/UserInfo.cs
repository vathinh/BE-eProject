namespace survey_be.Models
{
    public class UserInfo
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? UserPassword { get; set; }
        public string RollNo { get; set; }
        public string UserClass { get; set; }
        public string Specification { get; set; }
        public string Section { get; set; }
        public bool IsActive { get; set; }

        public int UserRoleId { get; set; }
        public virtual UserRole UserRole { get; set; }

        public virtual ICollection<SupportInformation> SupportInformations { get; set; }
        public virtual ICollection<Response> Responses { get; set; }




    }
}
