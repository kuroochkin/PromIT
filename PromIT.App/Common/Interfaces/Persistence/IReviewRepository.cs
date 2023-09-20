using PromIT.Domain.Review;

namespace PromIT.App.Common.Interfaces.Persistence;

public interface IReviewRepository : IGenericRepository<ReviewEntity>
{
	Task<ReviewEntity?> FindReviewWithReviewers(Guid id);
}
