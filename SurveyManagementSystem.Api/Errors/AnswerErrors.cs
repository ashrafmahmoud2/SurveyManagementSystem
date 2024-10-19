namespace SurveyManagementSystem.Api.Errors
{
    public static class AnswerErrors
    {
        public static readonly Error AnswerNotFound = new(
            "Answer.NotFound",
            "No answer was found with the given ID",
            StatusCodes.Status404NotFound);

        public static readonly Error DuplicatedAnswer = new(
            "Answer.DuplicatedAnswer",
            "Another answer with the same content exists",
            StatusCodes.Status409Conflict);
    }
}
