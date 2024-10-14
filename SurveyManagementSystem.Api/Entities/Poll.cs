using SurveyManagementSystem.Api.Entities;

namespace SurveyManagementSystem.Api.Entitles;

public class Poll: AuditableEntity
{
   public int Id { get; set; }

   public string Title { get; set; }

    public string Summary { get; set; }

    public bool IsPublished { get; set; }

    public DateTime StartAt { get; set; }=DateTime.Now;

}
