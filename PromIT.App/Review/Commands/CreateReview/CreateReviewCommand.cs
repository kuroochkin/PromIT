using ErrorOr;
using MediatR;

namespace PromIT.App.Review.Commands.CreateReview;

public record CreateReviewCommand(
	 string ReviewerId,
	 string CompanyName,
	 string? Address,
	 string Liked,
	 string? Unliked,
	 int Grade) : IRequest<ErrorOr<bool>>;

