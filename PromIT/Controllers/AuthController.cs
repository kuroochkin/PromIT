using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PromIT.API.Controllers;

public class AuthController : Controller
{
	private readonly ISender _mediator;
	private readonly IMapper _mapper;

	public AuthController(ISender mediator, IMapper mapper)
	{
		_mediator = mediator;
		_mapper = mapper;
	}
}
