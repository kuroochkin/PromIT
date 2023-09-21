using ErrorOr;
using MediatR;

namespace PromIT.App.Review.Commands.CreateReview;

public record CreateReviewCommand(
	 string ReviewerId,
	 string CompanyName,
	 string? Address,
	 string Liked,
	 string? Unliked,
	 string? Comment,
	 int Grade) : IRequest<ErrorOr<bool>>;

