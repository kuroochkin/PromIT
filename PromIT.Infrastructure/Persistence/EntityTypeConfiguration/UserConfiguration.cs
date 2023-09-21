using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PromIT.Domain.User;

namespace PromIT.Infrastructure.Persistence.EntityTypeConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
	public void Configure(EntityTypeBuilder<UserEntity> builder)
	{
		builder.ToTable("Users");

		builder.HasKey(user => user.Id);
		builder.Property(user => user.Nickname);
		builder.Property(user => user.Password);
		builder.Property(user => user.Type);
	}
}