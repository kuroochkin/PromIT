using ErrorOr;

namespace PromIT.App.Common.Errors;

public static partial class Errors
{
	public static class Auth
	{
		public static Error NicknameIsWasUsed => Error.Validation(
			code: "User.InvalidNickname",
			description: "Такой Nickname уже используется!");

		public static Error InvalidCredentials => Error.Validation(
			   code: "Auth.InvalidCred",
			   description: "Неверные учетные данные.");
	}
}
