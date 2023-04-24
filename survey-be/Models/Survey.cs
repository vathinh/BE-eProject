using System;
using System.Collections.Generic;

namespace survey_be.Models;

public partial class Survey
{
    public int SurveyId { get; set; }

    public int UserId { get; set; }

    public string SurveyType { get; set; } = null!;

    public string SurveyTitle { get; set; } = null!;

    public string SurveyName { get; set; } = null!;

    public string StatusSurvey { get; set; } = null!;

    public int? TotalMark { get; set; }

    public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();

    public virtual ICollection<Competition> Competitions { get; set; } = new List<Competition>();

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();

    public virtual Userdatum User { get; set; } = null!;
}
