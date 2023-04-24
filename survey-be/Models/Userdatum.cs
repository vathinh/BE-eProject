using System;
using System.Collections.Generic;

namespace survey_be.Models;

public partial class Userdatum
{
    public int UserId { get; set; }

    public string StatusId { get; set; } = null!;

    public string UserRole { get; set; } = null!;

    public string RegistrationType { get; set; } = null!;

    public string UserCode { get; set; } = null!;

    public string UserPassword { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public virtual ICollection<Faq> Faqs { get; set; } = new List<Faq>();

    public virtual ICollection<Prize> Prizes { get; set; } = new List<Prize>();

    public virtual ICollection<Supportinformation> Supportinformations { get; set; } = new List<Supportinformation>();

    public virtual ICollection<Survey> Surveys { get; set; } = new List<Survey>();

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
