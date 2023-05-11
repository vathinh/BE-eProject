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
            CreateMap<Survey, SurveyDTO>().ReverseMap(); 
            CreateMap<QuestionDTO, Question>();
            CreateMap<Question, QuestionDTO>().ReverseMap();
            CreateMap<AnswerDTO, Answer>();
            CreateMap<Answer, AnswerDTO>().ReverseMap();
            CreateMap<CompetitionContentDTO, CompetitionContent>();
            CreateMap<FaqDTO, Faq>();
            CreateMap<SupportInformationDTO, SupportInformation>();
            CreateMap<ResponseDTO, Response>();
            CreateMap<Response, ResponseDTO>().ReverseMap(); 

        }
    }
}
