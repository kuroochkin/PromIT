using PromIT.App.Common.Interfaces.Persistence;
using PromIT.Domain.Review;

namespace PromIT.Infrastructure.Persistence.Repositories;

public class ReviewRepository : GenericRepository<ReviewEntity>, IReviewRepository
{
	public ReviewRepository(ApplicationDbContext context) : base(context)
	{
	}
}
