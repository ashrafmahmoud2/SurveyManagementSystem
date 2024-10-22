namespace SurveyManagementSystem.Api.Contracts.Results;

public record VotesPerDayResponse
(
    DateTime Date,
    int NumbersOfVotes
);
