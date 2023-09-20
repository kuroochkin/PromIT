using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PromIT.App.Auth.Commands;
using PromIT.App.Auth.Queries;
using PromIT.Contracts.Auth;

namespace PromIT.API.Controllers;

[ApiController]
[Route("api/auth")]
[AllowAnonymous]
public class AuthController : Controller
{
	private readonly ISender _mediator;
	private readonly IMapper _mapper;

	public AuthController(ISender mediator, IMapper mapper)
	{
		_mediator = mediator;
		_mapper = mapper;
	}

	/// <summary>
	/// Регистрация пользователя
	/// </summary>
	/// <param name="request"></param>
	/// <returns></returns>
	[HttpPost("register")]
	public async Task<IActionResult> Register(RegisterRequest request)
	{
		var command = _mapper.Map<RegisterCommand>(request);

		var authResult = await _mediator.Send(command);

		return authResult.Match(
			authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
			errors => Problem("Ошибка")
			);
	}

	/// <summary>
	/// Авторизация пользователя
	/// </summary>
	/// <param name="request"></param>
	/// <returns></returns>
	[HttpPost("login")]
	public async Task<IActionResult> Login(LoginRequest request)
	{
		var query = new LoginQuery(request.Nickname, request.Password);

		var authResult = await _mediator.Send(query);

		return authResult.Match(
			authResult => Ok(new AuthenticationResponse(authResult.Token, authResult.TypeUser)),
			errors => Problem("Ошибка")
			);
	}



}
