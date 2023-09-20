using PromIT.Domain.User;

namespace PromIT.App.Common.Interfaces.Persistence;

public interface IUserRepository : IGenericRepository<UserEntity>
{
	Task<UserEntity?> FindUserByNickname(string nickname);
}
