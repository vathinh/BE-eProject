using System;
using System.Collections.Generic;

namespace survey_be.Models;

public partial class UserRole
{
    public int RoleId { get; set; }

    public int UserId { get; set; }

    public virtual Userdatum User { get; set; } = null!;
}
