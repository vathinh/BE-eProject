namespace survey_be.Models
{
    public class ResponseCompetitionResult
    {
        public Survey SurveyModel { get; set; }
        public Response ResponseModel { get; set; }
        public CompetitionResult CompetitionResultModel { get; set; }
        public CompetitionContent CompetitionContentModel { get; set; }
    }
}
