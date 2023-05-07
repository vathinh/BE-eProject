namespace survey_be.Models
{
    public class CompetitionResult
    {
        public int CompetitionResultId { get; set; }
        public int NumberUserJoined { get; set; }


        public int ResponseId { get; set; }
        public virtual Response Response { get; set; }

        public int PrizeId { get; set; }
        public virtual Prize Prize { get; set; }

        public int CompetitionContentId { get; set; }
        public virtual CompetitionContent CompetitionContent { get; set; }

    }
}
