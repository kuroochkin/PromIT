namespace PromIT.Contracts.Auth;

public record RegisterRequest(
	string Nickname,
	string Password,
	bool IsReviewer);