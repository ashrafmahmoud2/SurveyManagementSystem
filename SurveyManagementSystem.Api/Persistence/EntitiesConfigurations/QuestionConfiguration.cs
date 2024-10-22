using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SurveyManagementSystem.Api.Persistence.EntitiesConfigurations;

public class QuestionConfiguration : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        // builder.HasIndex(x => new { x.QuestionId, x.Content }).IsUnique();

        builder.Property(x => x.Content)
         .HasMaxLength(1000);

        builder.HasIndex(x => new { x.PollId, x.Content }).IsUnique();

    }
}
