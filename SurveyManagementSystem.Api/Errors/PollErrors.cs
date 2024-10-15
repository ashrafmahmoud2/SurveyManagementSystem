using SurveyManagementSystem.Api.Abstractions.ResultPattern;

namespace SurveyManagementSystem.Api.Errors;

public static class PollErrors
{
    public static readonly Error PollNotFound = new(
        "Poll.NotFound",
        "No Poll was found with the given Id",
        StatusCodes.Status404NotFound);

    public static readonly Error DuplicatedPollTitle = new(
        "Poll.DuplicatedPollTitle",
        "Another poll with the same title exists",
        StatusCodes.Status409Conflict);  
}
