﻿namespace SurveyManagementSystem.Api.Abstractions.ResultPattern;

public record Error(string Code,string Description ,int? StatusCode )
{
    public static readonly Error None=new(string.Empty,string.Empty,null);
}