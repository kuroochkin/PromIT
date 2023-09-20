using PromIT.App.Common.Interfaces.Persistence;
using PromIT.Domain.Administrator;

namespace PromIT.Infrastructure.Persistence.Repositories;

public class AdministratorRepository : GenericRepository<AdministratorEntity>, IAdministratorRepository
{
	public AdministratorRepository(ApplicationDbContext context) : base(context)
	{
	}
}
