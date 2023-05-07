namespace survey_be.Models
{
    public class Prize
    {
        public int PrizeId { get; set; }
        public string PrizeName { get; set; }
        public string PrizeDescription { get; set; }
        public virtual ICollection<CompetitionResult> CompetitionResults { get; set; }
    }
}
