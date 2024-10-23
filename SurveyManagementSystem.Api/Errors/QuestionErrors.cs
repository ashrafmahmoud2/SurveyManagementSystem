namespace SurveyManagementSystem.Api.Errors
{
    public static class QuestionErrors
    {
        public static readonly Error QuestionNotFound = new(
            "Question.NotFound",
            "No question was found with the given ID",
            StatusCodes.Status404NotFound);

        public static readonly Error DuplicatedQuestionContent = new(
            "Question.DuplicatedQuestionContent",
            "Another question with the same content exists",
            StatusCodes.Status409Conflict);
    }
}
