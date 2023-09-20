using PromIT.App.Common.Interfaces.Persistence;

namespace PromIT.Infrastructure.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork, IDisposable
{
	private readonly ApplicationDbContext _context;

	public UnitOfWork(ApplicationDbContext context,
		IUserRepository users,
		IReviewerRepository reviewers,
		IAdministratorRepository administrators,
		IReviewRepository reviews
		)
	{
		_context = context;
		Users = users;
		Reviewers = reviewers;
		Administrators = administrators;
		Reviews = reviews;
	}

	public IUserRepository Users { get; }
	public IReviewerRepository Reviewers { get; }
	public IAdministratorRepository Administrators { get; }
	public IReviewRepository Reviews { get; }

	public async Task<bool> CompleteAsync()
	{
		return await _context.SaveChangesAsync() > 0;
	}

	public void Dispose()
	{
		_context.Dispose();
	}
}
