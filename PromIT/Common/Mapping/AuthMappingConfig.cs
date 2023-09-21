using Mapster;
using PromIT.App.Auth.Commands;
using PromIT.Contracts.Auth;
using PromIT.App.Auth.Common;


namespace PromIT.API.Common.Mapping;

public class AuthMappingConfig : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<AuthenticationResult, AuthenticationResponse>();
		config.NewConfig<RegisterRequest, RegisterCommand>();
	}
}
