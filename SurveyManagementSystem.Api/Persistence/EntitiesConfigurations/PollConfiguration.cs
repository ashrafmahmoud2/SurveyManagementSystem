using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SurveyManagementSystem.Api.Entitles;

namespace SurveyManagementSystem.Api.Persistence.EntitiesConfigurations;
public class PollConfiguration : IEntityTypeConfiguration<Poll>
{
    public void Configure(EntityTypeBuilder<Poll> builder)
    {
        //builder.HasIndex(x => new { x.QuestionId, x.Content }).IsUnique();

        //builder.Property(x => x.Content).HasMaxLength(1000);
    }
}