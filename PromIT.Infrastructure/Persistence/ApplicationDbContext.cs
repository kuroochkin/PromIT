using Microsoft.EntityFrameworkCore;
using PromIT.Domain.Administrator;
using PromIT.Domain.Review;
using PromIT.Domain.Reviewer;
using PromIT.Domain.User;
using PromIT.Infrastructure.Persistence.EntityTypeConfiguration;

namespace PromIT.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
	public DbSet<UserEntity> Users { get; set; }
	public DbSet<ReviewerEntity> Reviewers { get; set; }
	public DbSet<AdministratorEntity> Administrators { get; set; }
	public DbSet<ReviewEntity> Reviews { get; set; }

	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
	   : base(options) { }

	protected override void OnModelCreating(ModelBuilder builder)
	{
		builder.ApplyConfiguration(new UserConfiguration());
		builder.ApplyConfiguration(new ReviewerConfiguration());
		builder.ApplyConfiguration(new AdministratorConfiguration());
		builder.ApplyConfiguration(new ReviewConfiguration());

		base.OnModelCreating(builder);
	}
}
