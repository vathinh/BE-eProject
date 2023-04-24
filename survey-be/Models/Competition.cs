using System;
using System.Collections.Generic;

namespace survey_be.Models;

public partial class Competition
{
    public int CompetitionId { get; set; }

    public int SurveyId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime TimeStartCompetition { get; set; }

    public DateTime TimeEndCompetition { get; set; }

    public string StatusCompetition { get; set; } = null!;

    public string Location { get; set; } = null!;

    public int NumberLimitUser { get; set; }

    public int NumberUserJoined { get; set; }

    public DateTime Duration { get; set; }

    public virtual ICollection<Prize> Prizes { get; set; } = new List<Prize>();

    public virtual Survey Survey { get; set; } = null!;
}
