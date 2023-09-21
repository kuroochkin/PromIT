using PromIT.Domain.User;

namespace PromIT.App.Common.Auth;

public interface IJwtTokenGenerator
{
	string GenerateToken(UserEntity user);
}
