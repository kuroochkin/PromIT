using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PromIT.App.Review.Commands.CreateReview;
using PromIT.App.Review.Queries.GetReviewDetails;
using PromIT.Contracts.Review;

namespace PromIT.API.Controllers;

[ApiController]
[Route("api/review")]
public class ReviewController : ApiController
{
	private readonly ISender _mediator;
	private readonly IMapper _mapper;

	public ReviewController(ISender mediator, IMapper mapper)
	{
		_mediator = mediator;
		_mapper = mapper;
	}

	/// <summary>
	/// Информация об отзыве
	/// </summary>
	/// <param name="reviewId"></param>
	/// <returns></returns>
	[HttpGet("{reviewId}")]
	public async Task<IActionResult> GetDetailsReview(string reviewId)
	{
		var query = new GetReviewDetailsQuery(reviewId);

		var orderResult = await _mediator.Send(query);

		return orderResult.Match(
			review => Ok(_mapper.Map<GetReviewDetailsResponse>(review)),
			errors => Problem("Ошибка")
		);
	}

	/// <summary>
	/// Добавление отзыва
	/// </summary>
	/// <param name="request"></param>
	/// <returns></returns>
	[HttpPost("create")]
	[Authorize(Roles = "Reviewer")]
	public async Task<IActionResult> CreateReview(CreateReviewRequest request)
	{
		var review = GetUserId();

		var command = _mapper.Map<CreateReviewCommand>((request, review));

		var result = await _mediator.Send(command);

		return result.Match(
			reviewResult => Ok(result.Value),
			errors => Problem("Ошибка")
			);
	}
}
