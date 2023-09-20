using Mapster;
using PromIT.App.Review.Commands.CreateReview;
using PromIT.Contracts.Review;

namespace PromIT.API.Common.Mapping;

public class ReviewMappingConfig : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<(CreateReviewRequest request, string reviewerId), CreateReviewCommand>()
			.Map(dest => dest.ReviewerId, src => src.reviewerId)
			.Map(dest => dest.CompanyName, src => src.request.CompanyName)
			.Map(dest => dest.Address, src => src.request.Address)
			.Map(dest => dest.Liked, src => src.request.Liked)
			.Map(dest => dest.Unliked, src => src.request.Unliked)
			.Map(dest => dest.Grade, src => src.request.Grade);
	}
}
