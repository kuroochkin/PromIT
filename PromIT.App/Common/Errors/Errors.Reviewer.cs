using ErrorOr;

namespace PromIT.App.Common.Errors;

public static partial class Errors
{
	public static class Reviewer
	{
		public static Error InvalidId => Error.Validation(
			code: "Reviewer.InvalidId",
			description: "Id рецензента не найден.");

		public static Error NotFound => Error.NotFound(
			code: "Reviewer.NotFound",
			description: "Рецензент не найден.");
	}
}
