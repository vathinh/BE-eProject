using AutoMapper;
using survey_be.Dtos;
using survey_be.Models;

namespace survey_be.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<SurveyDTO, Survey>();
            CreateMap<QuestionDTO, Question>();
            CreateMap<AnswerDTO, Answer>();
            CreateMap<CompetitionContentDTO, CompetitionContent>();
            CreateMap<FaqDTO, Faq>();
            CreateMap<SupportInformationDTO, SupportInformation>();

        }
    }
}
