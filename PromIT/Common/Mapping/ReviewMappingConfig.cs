using Mapster;
using PromIT.App.Review.Commands.CreateReview;
using PromIT.App.Review.Commands.DeleteReview;
using PromIT.App.Vm.Review;
using PromIT.Contracts.Review;

namespace PromIT.API.Common.Mapping;

public class ReviewMappingConfig : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<ReviewDetailsVm, GetReviewDetailsResponse>()
			.Map(dest => dest.ReviewId, src => src.ReviewId)
			.Map(dest => dest.Reviewer, src => src.Reviewer)
			.Map(dest => dest.CompanyName, src => src.CompanyName)
			.Map(dest => dest.Address, src => src.Address)
			.Map(dest => dest.Liked, src => src.Liked)
			.Map(dest => dest.Unliked, src => src.Unliked)
			.Map(dest => dest.Grade, src => src.Grade)
			.Map(dest => dest.Comment, src => src.Comment)
			.Map(dest => dest.Created, src => src.Created);

		config.NewConfig<(CreateReviewRequest request, string reviewerId), CreateReviewCommand>()
			.Map(dest => dest.ReviewerId, src => src.reviewerId)
			.Map(dest => dest.CompanyName, src => src.request.CompanyName)
			.Map(dest => dest.Address, src => src.request.Address)
			.Map(dest => dest.Liked, src => src.request.Liked)
			.Map(dest => dest.Unliked, src => src.request.Unliked)
			.Map(dest => dest.Comment, src => src.request.Comment)
			.Map(dest => dest.Grade, src => src.request.Grade);

		config.NewConfig<DeleteReviewRequest, DeleteReviewCommand>();

		config.NewConfig<ReviewsVm, GetAllReviewsResponse>()
			.Map(dest => dest.Reviews, src => src.Reviews);
	}
}
