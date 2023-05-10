namespace survey_be.Models
{
    public class SupportInformation
    {
        public int SupportInformationId { get; set; }
        public string SupportInformationContent { get; set; }
        public int UserId { get; set; }
        public virtual UserInfo UserInfo { get; set; }
    }
}
