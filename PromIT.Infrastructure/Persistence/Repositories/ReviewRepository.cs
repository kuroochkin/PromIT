using Microsoft.EntityFrameworkCore;
using PromIT.App.Common.Interfaces.Persistence;
using PromIT.Domain.Review;

namespace PromIT.Infrastructure.Persistence.Repositories;

public class ReviewRepository : GenericRepository<ReviewEntity>, IReviewRepository
{
	public ReviewRepository(ApplicationDbContext context) : base(context)
	{
	}

	public async Task<ReviewEntity?> FindReviewWithReviewers(Guid id)
	{
		return await _context.Reviews
			.Include(review => review.Reviewer)
			.FirstOrDefaultAsync(review => review.Id == id);
	}

	public async Task<List<ReviewEntity>?> GetAllReviewsWithReviewers()
	{
		return await _context.Reviews
			.Include(review => review.Reviewer)
			.OrderByDescending(review => review.Date)
			.ToListAsync();
	}
}
