using System;
using System.Collections.Generic;

namespace survey_be.Models;

public partial class Supportinformation
{
    public int SupportId { get; set; }

    public int UserId { get; set; }

    public string SupportContent { get; set; } = null!;

    public virtual Userdatum User { get; set; } = null!;
}
