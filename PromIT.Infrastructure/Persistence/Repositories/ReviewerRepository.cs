using PromIT.App.Common.Interfaces.Persistence;
using PromIT.Domain.Reviewer;

namespace PromIT.Infrastructure.Persistence.Repositories;

public class ReviewerRepository : GenericRepository<ReviewerEntity>, IReviewerRepository
{
	public ReviewerRepository(ApplicationDbContext context) : base(context)
	{
	}
}
