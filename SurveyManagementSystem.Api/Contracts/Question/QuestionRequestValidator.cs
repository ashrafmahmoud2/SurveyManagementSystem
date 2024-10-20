namespace SurveyManagementSystem.Api.Contracts.Question;

public class QuestionRequestValidator : AbstractValidator<QuestionRequest>
{
    public QuestionRequestValidator()
    {
        RuleFor(x => x.Content)
            .NotEmpty()
            .Length(20, 10000);

        RuleFor(x => x.Answers)
            .NotNull();


        RuleFor(x => x.Answers)
        .Must(x => x.Count > 1)
        .WithMessage("Question should has at least 2 answers")
        .When(x => x.Answers != null);

        RuleFor(x => x.Answers)
            .Must(x => x.Distinct().Count() == x.Count) //Distinct:Count unduplicated value in answers 
            .WithMessage("You cannot add duplicated answers for the same question")
            .When(x => x.Answers != null);




    }
}
