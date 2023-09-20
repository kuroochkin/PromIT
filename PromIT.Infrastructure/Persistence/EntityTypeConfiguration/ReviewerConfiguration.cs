using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PromIT.Domain.Reviewer;

namespace PromIT.Infrastructure.Persistence.EntityTypeConfiguration;

public class ReviewerConfiguration : IEntityTypeConfiguration<ReviewerEntity>
{
	public void Configure(EntityTypeBuilder<ReviewerEntity> builder)
	{
		builder.ToTable("Reviewers");

		builder.HasKey(reviewer => reviewer.Id);
		builder.Property(reviewer => reviewer.Nickname);
	}
}
