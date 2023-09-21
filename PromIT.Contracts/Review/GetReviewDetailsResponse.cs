using PromIT.Contracts.Reviewer;

namespace PromIT.Contracts.Review;

public record GetReviewDetailsResponse(
	string ReviewId,
	ReviewerResponse Reviewer,
	DateTime Created,
	string CompanyName,
	string? Address,
	string Liked,
	string? Unliked,
	string? Comment,
	int Grade);

