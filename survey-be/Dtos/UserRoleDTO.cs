using survey_be.Models;

namespace survey_be.Dtos
{
    public class UserRoleDTO
    {
        public int UserRoleId { get; set; }
        public string UserRoleName { get; set; }
        public virtual ICollection<UserInfo> UserInfos { get; set; }
        public virtual ICollection<Survey> Surveys { get; set; }
    }
}
