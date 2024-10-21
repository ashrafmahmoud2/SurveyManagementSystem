namespace SurveyManagementSystem.Api.Contracts.Vote;

public class VoteRequestValidator: AbstractValidator<VoteRequest>
{
    public VoteRequestValidator()
    {
        RuleFor(x => x.Answers)
            .NotEmpty();


        // Apply the VoteAnswerRequestValidator to each element in the Answers collection to be  .GreaterThan(0)
        RuleForEach(x => x.Answers)
            .SetInheritanceValidator(v => v.Add(new VoteAnswerRequestValidator()));
    }
}
