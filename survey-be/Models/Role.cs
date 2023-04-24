using System;
using System.Collections.Generic;

namespace survey_be.Models;

public partial class Role
{
    public int RoleId { get; set; }

    public string RoleDescription { get; set; } = null!;

    public string RoleName { get; set; } = null!;
}
