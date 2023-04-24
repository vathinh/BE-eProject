using System;
using System.Collections.Generic;

namespace survey_be.Models;

public partial class Status
{
    public int StatusId { get; set; }

    public string StatusContent { get; set; } = null!;

    public string? Description { get; set; }
}
