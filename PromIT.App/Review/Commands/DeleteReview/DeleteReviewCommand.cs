using ErrorOr;
using MediatR;

namespace PromIT.App.Review.Commands.DeleteReview;

public record DeleteReviewCommand(
	string ReviewId) : IRequest<ErrorOr<bool>>;

