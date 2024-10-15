using SurveyManagementSystem.Api.Entities;

namespace SurveyManagementSystem.Api.Entitles;

public class Poll: AuditableEntity
{
   public int Id { get; set; }

   public string Title { get; set; }=string.Empty;

    public string Summary { get; set; }=string.Empty;

    public DateOnly StartsAt { get; set; }

    public DateOnly EndsAt { get; set; }

    public bool IsPublished { get; set; }


}
