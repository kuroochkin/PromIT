using MediatR;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PromIT.App.Common.Behavior;
using System.Reflection;

namespace PromIT.App;

public static class DependencyInjection
{
	public static IServiceCollection AddApplication(this IServiceCollection services)
	{
		services.AddMediatR(typeof(DependencyInjection).Assembly);
		services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
		services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

		return services;
	}
}
