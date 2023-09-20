using ErrorOr;
using MediatR;
using PromIT.App.Auth.Common;

namespace PromIT.App.Auth.Queries;

public record LoginQuery(
	string Nickname,
	string Password
	) : IRequest<ErrorOr<AuthenticationResult>>;
