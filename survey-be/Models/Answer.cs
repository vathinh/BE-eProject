using System;
using System.Collections.Generic;

namespace survey_be.Models;

public partial class Answer
{
    public int AnswerId { get; set; }

    public int QuestionId { get; set; }

    public int SurveyId { get; set; }

    public string? AnswerContent { get; set; }

    public int Mark { get; set; }

    public virtual Question Question { get; set; } = null!;

    public virtual Survey Survey { get; set; } = null!;
}
