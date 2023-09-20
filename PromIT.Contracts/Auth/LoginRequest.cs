namespace PromIT.Contracts.Auth;

public record LoginRequest(
	string Nickname,
	string Password);
