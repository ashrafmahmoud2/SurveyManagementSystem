﻿namespace SurveyManagementSystem.Api.Contracts.Auth;

public record LoginRequest(
    string Email,
    string Password
    );
