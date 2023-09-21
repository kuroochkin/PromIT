using ErrorOr;
using MediatR;
using PromIT.App.Common.Errors;
using PromIT.App.Common.Interfaces.Persistence;
using PromIT.App.Vm.Review;
using PromIT.App.Vm.Reviewer;

namespace PromIT.App.Review.Queries.GetAllReviews;

public class GetAllReviewsQueryHandler
	: IRequestHandler<GetAllReviewsQuery, ErrorOr<ReviewsVm>>
{
	private readonly IUnitOfWork _unitOfWork;

	public GetAllReviewsQueryHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}
	public async Task<ErrorOr<ReviewsVm>> Handle(
		GetAllReviewsQuery request, 
		CancellationToken cancellationToken)
	{
		// Получаем список всех отзывов
		var reviews = await _unitOfWork.Reviews.GetAllReviewsWithReviewers();
		if(reviews is null)
		{
			return Errors.Reviewer.NotFound;
		}

		// Создаем модель списка всех отзывов
		var reviewsInfo = reviews.Select(review => new ReviewDetailsVm(
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
			review.Grade)
			)
			.ToList();

		// Возвращаем модель всех отзывов
		return new ReviewsVm(reviewsInfo);
	}
}
