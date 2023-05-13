namespace survey_be.Dtos
{
    public class UserParticipantsDTO
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public virtual ICollection<ParticipatesDTO> Responses { get; set; }

    }
}
