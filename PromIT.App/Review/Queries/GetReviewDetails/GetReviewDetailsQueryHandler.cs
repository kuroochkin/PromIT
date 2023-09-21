using ErrorOr;
using MediatR;
using PromIT.App.Common.Errors;
using PromIT.App.Common.Interfaces.Persistence;
using PromIT.App.Vm.Review;
using PromIT.App.Vm.Reviewer;

namespace PromIT.App.Review.Queries.GetReviewDetails;

class GetReviewDetailsQueryHandler
   : IRequestHandler<GetReviewDetailsQuery, ErrorOr<ReviewDetailsVm>>
{
	private readonly IUnitOfWork _unitOfWork;

	public GetReviewDetailsQueryHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}


	public async Task<ErrorOr<ReviewDetailsVm>> Handle(
		GetReviewDetailsQuery request, 
		CancellationToken cancellationToken)
	{
		if (!Guid.TryParse(request.ReviewId, out var reviewId))
		{
			return Errors.Review.InvalidId;
		}

		var review = await _unitOfWork.Reviews.FindReviewWithReviewers(reviewId);
		if (review is null)
		{
			return Errors.Review.NotFound;
		}

		var reviewInfo = new ReviewDetailsVm(
			review.Id.ToString(),
			new ReviewerVm(
				review.Reviewer.Id.ToString(),
				review.Reviewer.Nickname),
			review.Date,
			review.CompanyName,
			review?.Address,
			review.Liked,
			review?.Unliked,
			review?.Comment,
			review.Grade
			);

		return reviewInfo;
	}
}
