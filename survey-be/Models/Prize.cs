using System;
using System.Collections.Generic;

namespace survey_be.Models;

public partial class Prize
{
    public int PrizeId { get; set; }

    public int UserId { get; set; }

    public int CompetitionId { get; set; }

    public string PrizeName { get; set; } = null!;

    public string? PrizeDescription { get; set; }

    public virtual Competition Competition { get; set; } = null!;

    public virtual Userdatum User { get; set; } = null!;
}
