using ErrorOr;
using MediatR;
using PromIT.App.Auth.Common;

namespace PromIT.App.Auth.Commands;

public record RegisterCommand(
	string Nickname,
	string Password,
	bool IsReviewer) : IRequest<ErrorOr<AuthenticationResult>>;