using System;
using System.Collections.Generic;

namespace survey_be.Models;

public partial class Faq
{
    public int FaqId { get; set; }

    public int UserId { get; set; }

    public string FaqContent { get; set; } = null!;

    public virtual Userdatum User { get; set; } = null!;
}
