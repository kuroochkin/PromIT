using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PromIT.Domain.Administrator;

namespace PromIT.Infrastructure.Persistence.EntityTypeConfiguration;

public class AdministratorConfiguration : IEntityTypeConfiguration<AdministratorEntity>
{
	public void Configure(EntityTypeBuilder<AdministratorEntity> builder)
	{
		builder.ToTable("Administrators");

		builder.HasKey(administrator => administrator.Id);
		builder.Property(administrator => administrator.Nickname);
	}
}
