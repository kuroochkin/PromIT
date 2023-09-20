using PromIT.App.Common.Interfaces.Persistence;
using PromIT.Domain.Administrator;

namespace PromIT.Infrastructure.Persistence.Repositories;

public class AdministratorRepositoty : IGenericRepository<AdministratorEntity>, IAdministratorRepository
{
	public AdministratorRepositoty(ApplicationDbContext context) : base(context)
	{
	}
}
