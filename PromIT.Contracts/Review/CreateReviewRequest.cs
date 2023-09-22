namespace PromIT.Contracts.Review;

public record CreateReviewRequest(
	 string CompanyName,
	 string? Address,
	 string Liked,
	 string? Unliked,
	 string? Comment,
	 int Grade);
