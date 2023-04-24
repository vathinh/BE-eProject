using System;
using System.Collections.Generic;

namespace survey_be.Models;

public partial class Question
{
    public int QuestionId { get; set; }

    public int SurveyId { get; set; }

    public string AnswerContent { get; set; } = null!;

    public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();

    public virtual Survey Survey { get; set; } = null!;
}
