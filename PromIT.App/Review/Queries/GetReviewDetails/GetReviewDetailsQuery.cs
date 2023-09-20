using ErrorOr;
using MediatR;
using PromIT.App.Vm.Review;

namespace PromIT.App.Review.Queries.GetReviewDetails;

public record GetReviewDetailsQuery(
	string ReviewId) : IRequest<ErrorOr<ReviewDetailsVm>>;

