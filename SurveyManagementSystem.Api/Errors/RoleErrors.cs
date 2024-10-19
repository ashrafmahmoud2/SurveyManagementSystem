namespace SurveyManagementSystem.Api.Errors
{
    public static class RoleErrors
    {
        public static readonly Error RoleNotFound = new(
            "Role.NotFound",
            "No role was found with the given name",
            StatusCodes.Status404NotFound);

        public static readonly Error DuplicatedRole = new(
            "Role.DuplicatedRole",
            "Another role with the same name exists",
            StatusCodes.Status409Conflict);
    }
}
