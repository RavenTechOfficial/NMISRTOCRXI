using ServiceLayer.Services.IRepositories;
using InfastructureLayer.Data;
using DomainLayer.Models;

namespace InfastructureLayer.Repositories
{
	public class AccountDetailsRepository : Repository<AccountDetail>, IAccountDetailsRepository
	{
		private readonly AppDbContext _context;

		public AccountDetailsRepository(AppDbContext context) : base(context)
		{
			_context = context;
		}
		public void Update(AccountDetail entity)
		{
			_context.Update(entity);
		}
	}
}
