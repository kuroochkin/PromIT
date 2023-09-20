namespace PromIT.Contracts.Review;

public record CreateReviewRequest(
	 string ReviewerId,
	 string CompanyName,
	 string? Address,
	 string Liked,
	 string? Unliked,
	 int Grade);
