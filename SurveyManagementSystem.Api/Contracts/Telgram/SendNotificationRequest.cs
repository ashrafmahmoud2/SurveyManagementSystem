﻿using System.ComponentModel.DataAnnotations;

namespace SurveyManagementSystem.Api.Contracts.Telgram;

public record SendNotificationRequest
(string Message, string ChatId);
