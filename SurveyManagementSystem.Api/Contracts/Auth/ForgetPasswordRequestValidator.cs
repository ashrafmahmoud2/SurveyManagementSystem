﻿namespace SurveyManagementSystem.Api.Contracts.Auth;

public class ForgetPasswordRequestValidator:AbstractValidator<ForgetPasswordRequest>
{
    public ForgetPasswordRequestValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();
    }
}