using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PromIT.Domain.Review;

namespace PromIT.Infrastructure.Persistence.EntityTypeConfiguration;

public class ReviewConfiguration : IEntityTypeConfiguration<ReviewEntity>
{
	public void Configure(EntityTypeBuilder<ReviewEntity> builder)
	{
		builder.ToTable("Reviews");

		builder.HasKey(review => review.Id);
		builder.Property(review => review.CompanyName);
		builder.Property(review => review.Address);
		builder.Property(review => review.Liked);
		builder.Property(review => review.Unliked);
		builder.Property(review => review.Date);
		builder.Property(review => review.Grade);
		builder.Property(review => review.Comment);
	}
}