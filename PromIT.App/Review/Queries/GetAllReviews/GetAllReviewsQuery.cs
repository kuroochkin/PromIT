using ErrorOr;
using MediatR;
using PromIT.App.Vm.Review;

namespace PromIT.App.Review.Queries.GetAllReviews;

public record GetAllReviewsQuery : IRequest<ErrorOr<ReviewsVm>>;

