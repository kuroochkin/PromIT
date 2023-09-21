using ErrorOr;
using MediatR;
using PromIT.App.Auth.Common;
using PromIT.App.Common.Auth;
using PromIT.App.Common.Errors;
using PromIT.App.Common.Interfaces.Persistence;
using PromIT.Domain.Administrator;
using PromIT.Domain.Reviewer;
using PromIT.Domain.User;
using static PromIT.Domain.User.UserEntity;

namespace PromIT.App.Auth.Commands;

public class RegisterCommandHandler
	: IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
	
	private readonly IUnitOfWork _unitOfWork;
	private readonly IJwtTokenGenerator _jwtTokenGenerator;

	public RegisterCommandHandler(
	   IUnitOfWork unitOfWork,
	   IJwtTokenGenerator jwtTokenGenerator)
	{
		_unitOfWork = unitOfWork;
		_jwtTokenGenerator = jwtTokenGenerator;
	}

	public async Task<ErrorOr<AuthenticationResult>> Handle(
		RegisterCommand request, 
		CancellationToken cancellationToken)
	{
		//Проверяем валидность Nickname
		if (await _unitOfWork.Users.FindUserByNickname(request.Nickname) is not null)
		{
			return Errors.Auth.NicknameIsWasUsed;
		}

		// Хэширование пароля
		var passwordHashed = PasswordHasher.HashPassword(request.Password);

		UserEntity user;

		//Создаем объект пользователя и определяем его роль
		if (request.IsReviewer)
			user = new UserEntity(request.Nickname, passwordHashed, UserType.Reviewer);
		else
			user = new UserEntity(request.Nickname, passwordHashed, UserType.Administrator);

		//Добавляем пользователя в коллекцию
		await _unitOfWork.Users.Add(user);

		if (user.GetTypeUser == UserType.Reviewer)
		{
			var reviewer = new ReviewerEntity(user.Id, user.Nickname);
			await _unitOfWork.Reviewers.Add(reviewer);
		}
		else
		{
			var administrator = new AdministratorEntity(user.Id, user.Nickname);
			await _unitOfWork.Administrators.Add(administrator);
		}

		//Сохраняем данные
		await _unitOfWork.CompleteAsync();

		// Выдаем токен пользователю
		var token = _jwtTokenGenerator.GenerateToken(user);

		return new AuthenticationResult(token, user.GetUserTypeToString());
	}
}
