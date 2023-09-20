using ErrorOr;
using MediatR;
using PromIT.App.Common.Errors;
using PromIT.App.Common.Interfaces.Persistence;
using PromIT.Domain.Review;
using static PromIT.App.Common.Errors.Errors;
using System.Diagnostics;
using System.Net;

namespace PromIT.App.Review.Commands.CreateReview;

public class CreateReviewCommandHandler
	: IRequestHandler<CreateReviewCommand, ErrorOr<bool>>
{
	
	private readonly IUnitOfWork _unitOfWork;

	public CreateReviewCommandHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async Task<ErrorOr<bool>> Handle(
		CreateReviewCommand request, 
		CancellationToken cancellationToken)
	{
		if (!Guid.TryParse(request.ReviewerId, out var reviewerId))
		{
			return Errors.Reviewer.InvalidId;
		}

		var reviewer = await _unitOfWork.Reviewers.FindById(reviewerId);
		if (reviewer is null)
		{
			return Errors.Reviewer.NotFound;
		}

		var review = new ReviewEntity(
			reviewer,
			request.CompanyName,
			request.Liked,
			request.Grade
			);

		review.Address = request.Address;
		review.Unliked = request.Unliked;

		if (await _unitOfWork.Reviews.Add(review))
		{
			return await _unitOfWork.CompleteAsync();
		}

		return false;
	}
}
