namespace PromIT.App.Common.Interfaces.Persistence;

public interface IUnitOfWork
{
	IUserRepository Users { get; }
	IReviewerRepository Reviewers { get; }
	IAdministratorRepository Administrators { get; }
	IReviewRepository Reviews { get;}
}
