namespace survey_be.Models
{
    public class UserRole
    {
        public int UserRoleId { get; set; }
        public string UserRoleName { get; set; }
        public virtual ICollection<UserInfo> UserInfos { get; set; }
        public virtual ICollection<Survey> Surveys{ get; set; }
    }
}
