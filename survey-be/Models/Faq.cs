using System.ComponentModel.DataAnnotations;

namespace survey_be.Models
{
    public class Faq
    {
        [Key]
        public int FaqId { get; set; }
        public string FaqQuestion { get; set; }
        public string FaqContent { get; set; }
    }
}
