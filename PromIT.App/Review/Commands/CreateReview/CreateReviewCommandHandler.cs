using ErrorOr;
using MediatR;
using PromIT.App.Common.Errors;
using PromIT.App.Common.Interfaces.Persistence;
using PromIT.Domain.Review;

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
		// Проверяем валидность Id
		if (!Guid.TryParse(request.ReviewerId, out var reviewerId))
		{
			return Errors.Reviewer.InvalidId;
		}

		// Находим резенцента
		var reviewer = await _unitOfWork.Reviewers.FindById(reviewerId);
		if (reviewer is null)
		{
			return Errors.Reviewer.NotFound;
		}

		// Создаем и инициализируем объект отзыва
		var review = new ReviewEntity(
			reviewer,
			request.CompanyName,
			request.Liked,
			request.Grade
			);

		review.Address = request.Address;
		review.Unliked = request.Unliked;
		review.Comment = request.Comment;

		// Добавляем в базу данных и сохраняем
		if (await _unitOfWork.Reviews.Add(review))
		{
			return await _unitOfWork.CompleteAsync();
		}

		return false;
	}
}
