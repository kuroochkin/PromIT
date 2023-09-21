using PromIT.Domain.Reviewer;

namespace PromIT.Domain.Review;

public class ReviewEntity
{
    public Guid Id { get; set; }

    public DateTime Date { get; set; }

    public ReviewerEntity Reviewer { get; set; } = null!;

    public string CompanyName { get; set; } = null!;

    public string? Address { get; set; }

    public string Liked { get; set; } = null!;

    public string? Unliked { get; set; }

    public string? Comment { get; set; }

    public int Grade { get; set; }

    public ReviewEntity()
    {

    }

    public ReviewEntity(
        ReviewerEntity reviewer,
        string companyName,
        string liked,
        int grade)
    {
        Id = Guid.NewGuid();
        Date = DateTime.Now;
        Reviewer = reviewer;
        CompanyName = companyName;
        Liked = liked;
        Grade = grade;
    }
}
