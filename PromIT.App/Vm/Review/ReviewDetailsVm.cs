using PromIT.App.Vm.Reviewer;

namespace PromIT.App.Vm.Review;

public record ReviewDetailsVm(
    string ReviewId,
    ReviewerVm Reviewer,
    DateTime Created,
    string CompanyName,
    string? Address,
    string Liked,
    string? Unliked,
    int Grade
    );



