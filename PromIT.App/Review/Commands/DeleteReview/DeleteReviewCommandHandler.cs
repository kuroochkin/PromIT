﻿using ErrorOr;
using MediatR;
using PromIT.App.Common.Errors;
using PromIT.App.Common.Interfaces.Persistence;

namespace PromIT.App.Review.Commands.DeleteReview;

public class DeleteReviewCommandHandler
	: IRequestHandler<DeleteReviewCommand, ErrorOr<bool>>
{
	private readonly IUnitOfWork _unitOfWork;

	public DeleteReviewCommandHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async Task<ErrorOr<bool>> Handle(
		DeleteReviewCommand request,
		CancellationToken cancellationToken)
	{
		if (!Guid.TryParse(request.ReviewId, out var reviewId))
		{
			return Errors.Review.InvalidId;
		}

		var review = await _unitOfWork.Reviews.FindReviewWithReviewers(reviewId);
		if(review is null)
		{
			return Errors.Review.NotFound;
		}

		if (_unitOfWork.Reviews.Delete(review))
		{
			return await _unitOfWork.CompleteAsync();
		}

		return false;
	}
}
