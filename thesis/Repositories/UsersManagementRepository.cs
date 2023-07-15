using Microsoft.EntityFrameworkCore;
using thesis.Areas.Identity.Data;
using thesis.Core.IRepositories;
using thesis.Data;

namespace thesis.Repositories
{
	public class UsersManagementRepository : IUsersManangementRepository
	{
		private readonly thesisContext _context;

		public UsersManagementRepository(thesisContext context)
        {
			_context = context;
		}
        public IEnumerable<AccountDetails> GetAllUsersAsync()
		{
			return _context.Users.ToList();
		}
	}
}
