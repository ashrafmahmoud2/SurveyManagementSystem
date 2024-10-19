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
    }
}
