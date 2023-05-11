using System.ComponentModel.DataAnnotations;

namespace survey_be.Models
{
    public class SupportInformation
    {
        [Key]
        public int SupportInformationId { get; set; }
        public string SupportInformationContent { get; set; }
        public int UserId { get; set; }
        public virtual UserInfo UserInfo { get; set; }
    }
}
