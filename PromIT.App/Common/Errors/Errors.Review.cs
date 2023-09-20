using ErrorOr;

namespace PromIT.App.Common.Errors;


public static partial class Errors
{
	public static class Review
	{
		public static Error InvalidId => Error.Validation(
			code: "Review.InvalidId",
			description: "Id отзыва не найден.");

		public static Error NotFound => Error.NotFound(
			code: "Review.NotFound",
			description: "Отзыв не найден.");
	}
}
