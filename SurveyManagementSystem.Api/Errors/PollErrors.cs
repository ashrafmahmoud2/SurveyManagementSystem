﻿namespace SurveyManagementSystem.Api.Errors
{
    public static class PollErrors
    {
        public static readonly Error PollNotFound = new(
            "Poll.NotFound",
            "No poll was found with the given ID",
            StatusCodes.Status404NotFound);

        public static readonly Error DuplicatedPollTitle = new(
            "Poll.DuplicatedPollTitle",
            "Another poll with the same title exists",
            StatusCodes.Status409Conflict);
    }
}
