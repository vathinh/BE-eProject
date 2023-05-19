using survey_be.Models;

namespace survey_be.Dtos
{
    public class UserDTO
    {
		public int UserId { get; set; } // ver 01
		public string UserName { get; set; }
		public string Password { get; set; }
		public string FullName { get; set; } // ver 01
		public required string RollNo { get; set; }
		public string UserClass { get; set; } // ver 01
		public string Specification { get; set; } // ver 01
		public string Section { get; set; } // ver 01
		public DateTime AdmissionDate { get; set; } // ver 01
		public bool IsActive { get; set; } // ver 01

		public virtual ICollection<SupportInformationDTO> SupportInformations { get; set; } // ver02
		public virtual ICollection<ResponseDTO> Responses { get; set; } // ver 02

	}
}
