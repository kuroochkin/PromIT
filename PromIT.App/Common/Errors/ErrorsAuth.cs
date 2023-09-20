using ErrorOr;

namespace PromIT.App.Common.Errors;

public static partial class Errors
{
	public static class Auth
	{
		public static Error NicknameIsWasUsed => Error.Validation(
			code: "User.InvalidNickname",
			description: "Такой Nickname уже используется!");
	}
}
