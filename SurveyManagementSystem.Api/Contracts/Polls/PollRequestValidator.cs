using FluentValidation;

namespace SurveyManagementSystem.Api.Contracts.Polls;

public class PollRequestValidator : AbstractValidator<PollRequest>
{
    public PollRequestValidator()
    {


        RuleFor(x => x.Title)
            .NotEmpty()
            .Length(3, 10000);
           
          
            

        RuleFor(x => x.Summary)
            .NotEmpty()
            .Length(3, 10000);
        

        RuleFor(p => p.StartAt)
            .NotEmpty()
            .GreaterThanOrEqualTo(DateTime.Today).WithMessage("Start date cannot be in the past.");

        RuleFor(p => p.EndAt)
            .NotEmpty()
            .GreaterThan(p => p.StartAt).WithMessage("End date must be after the start date.");


    }
}
