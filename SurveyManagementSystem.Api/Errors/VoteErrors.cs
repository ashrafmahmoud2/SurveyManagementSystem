namespace SurveyManagementSystem.Api.Errors
{
    public static class VoteErrors
    {
        public static readonly Error VoteNotFound = new(
            "Vote.NotFound",
            "No vote was found with the given ID",
            StatusCodes.Status404NotFound);

        public static readonly Error DuplicatedVote = new(
            "Vote.DuplicatedVote",
            "Another vote with the same details exists",
            StatusCodes.Status409Conflict);

        public static readonly Error InvalidQuestion = new(
           "Vote.InvalidQuestion",
           "Invalid Question",
           StatusCodes.Status409Conflict);
    }
}
