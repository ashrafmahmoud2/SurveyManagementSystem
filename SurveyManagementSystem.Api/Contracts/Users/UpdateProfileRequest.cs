﻿namespace SurveyManagementSystem.Api.Contracts.Users;

public record UpdateProfileRequest
(

    string FirstName,
    string LastName,
    string Email


);
