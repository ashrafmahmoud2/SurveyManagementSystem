﻿using Mapster;
using Microsoft.AspNetCore.Identity.Data;
using SurveyManagementSystem.Api.Entitles;

namespace SurveyManagementSystem.Api.Mapping;

public class MappingConfigurations : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        //config.NewConfig<QuestionRequest, Question>()
        //    .Map(dest => dest.Answers, src => src.Answers.Select(answer => new Answer { Content = answer }));

        //config.NewConfig<RegisterRequest, ApplicationUser>()
        //    .Map(dest => dest.UserName, src => src.Email);


    }
}