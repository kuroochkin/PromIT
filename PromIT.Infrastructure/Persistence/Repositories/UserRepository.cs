using PromIT.App.Common.Interfaces.Persistence;
using PromIT.Domain.Review;
using PromIT.Domain.User;

namespace PromIT.Infrastructure.Persistence.Repositories;


public class UserRepository : GenericRepository<UserEntity>, IUserRepository
{
	public UserRepository(ApplicationDbContext context) : base(context)
	{

	}
}


