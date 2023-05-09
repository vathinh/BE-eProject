using System.ComponentModel.DataAnnotations;

namespace survey_be.Dtos
{
    public class FaqDTO
    {
        public int FaqId { get; set; }
        public string FaqQuestion { get; set; }
        public string FaqContent { get; set; }
    }
}
