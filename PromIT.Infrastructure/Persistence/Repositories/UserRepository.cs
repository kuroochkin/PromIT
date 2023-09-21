using Microsoft.EntityFrameworkCore;
using PromIT.App.Common.Interfaces.Persistence;
using PromIT.Domain.User;

namespace PromIT.Infrastructure.Persistence.Repositories;


public class UserRepository : GenericRepository<UserEntity>, IUserRepository
{
	public UserRepository(ApplicationDbContext context) : base(context)
	{

	}

	public async Task<UserEntity?> FindUserByNickname(string nickname)
	{
		return await _context.Users
			.FirstOrDefaultAsync(user => user.Nickname == nickname);
	}
}


