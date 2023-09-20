using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PromIT.App.Common.Interfaces.Persistence;
using PromIT.Infrastructure.Persistence;
using PromIT.Infrastructure.Persistence.Repositories;

namespace PromIT.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddScoped<IUserRepository, UserRepository>();
		services.AddScoped<IReviewerRepository, ReviewerRepository>();
		services.AddScoped<IAdministratorRepository, AdministratorRepository>();
		services.AddScoped<IReviewRepository, ReviewRepository>();

		services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("SqlServer"));
        });

        return services;
    }
}
