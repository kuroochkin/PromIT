using ErrorOr;
using MediatR;
using PromIT.App.Auth.Common;
using PromIT.App.Common.Auth;
using PromIT.App.Common.Errors;
using PromIT.App.Common.Interfaces.Persistence;

namespace PromIT.App.Auth.Queries;

public class LoginQueryHandler
	: IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IJwtTokenGenerator _jwtTokenGenerator;

	public LoginQueryHandler(
			IUnitOfWork unitOfWork,
			IJwtTokenGenerator jwtTokenGenerator)
	{
		_unitOfWork = unitOfWork;
		_jwtTokenGenerator = jwtTokenGenerator;
	}

	public async Task<ErrorOr<AuthenticationResult>> Handle(
		LoginQuery request, 
		CancellationToken cancellationToken)
	{
		// Находим пользователя и проверяем валидность введенных данных
		var user = await _unitOfWork.Users.FindUserByNickname(request.Nickname);
		if (user is not null)
		{
			if (PasswordHasher.VerifyPassword(request.Password, user.Password))
			{
				var token = _jwtTokenGenerator.GenerateToken(user);
				return new AuthenticationResult(token, user.Type.ToString());
			}
		}
		return Errors.Auth.InvalidCredentials;
	}
}
