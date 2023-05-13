﻿using AutoMapper;
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
            CreateMap<Response, ParticipatesDTO>()
                .ForMember(dest => dest.SurveyId, opt => opt.MapFrom(src => src.Survey.SurveyId))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Survey.Title))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserInfo.UserId))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserInfo.UserName));

            CreateMap<Survey, SurveyParticipantsDTO>().ReverseMap();
            CreateMap<UserInfo, UserParticipantsDTO>().ReverseMap();




        }
    }
}
