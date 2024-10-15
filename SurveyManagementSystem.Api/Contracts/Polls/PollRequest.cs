﻿namespace SurveyManagementSystem.Api.Contracts.Polls;

public record PollRequest
(
 string Title,
 string Summary,
 DateTime StartAt,
 DateTime EndAt
);
