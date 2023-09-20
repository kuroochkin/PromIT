using PromIT.Domain.Review;

namespace PromIT.Domain.Reviewer;

public class ReviewerEntity
{
	public Guid Id { get; set; }

	public string Nickname { get; set; } = null!;

	List<ReviewEntity> Reviews { get; set; } = new();

	public ReviewerEntity()
	{
	}
}
