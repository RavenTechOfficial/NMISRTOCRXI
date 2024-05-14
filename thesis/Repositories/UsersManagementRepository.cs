using Microsoft.EntityFrameworkCore;
using DomainLayer.Models;
using thesis.Core.IRepositories;
using DomainLayer.Models.ViewModels;
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

		public bool AccountDetailsExist(string id)
		{
			return _context.Users.Any(u => u.Id == id);
		}

		public bool Delete(AccountDetails accountDetails)
		{
			_context.Remove(accountDetails);
			return Save();
		}

		public async Task<AccountDetails> GetAccountDetails(string accountId)
		{
			return await _context.Users.FirstOrDefaultAsync(p => p.Id == accountId);
		}

		public async Task<AccountDetails> GetAccountDetailsByAsyncNoTracking(string accountId)
		{
			return await _context.Users.AsNoTracking().FirstOrDefaultAsync(p => p.Id == accountId);
		}

		public async Task<IEnumerable<AccountDetails>> GetAllUsersAsync()
		{
			return await _context.Users.ToListAsync();
		}

		public bool Update(AccountUserViewModel accountDetails)
		{
			var account = _context.Users.Find(accountDetails.Id);

			if (account == null)
			{
				return false;
			}

			// Update the properties of the AccountDetails entity
			account.firstName = accountDetails.firstName;
			account.lastName = accountDetails.lastName;
			account.middleName = accountDetails.middleName;
			account.contactNo = accountDetails.contactNo;
			account.birthdate = accountDetails.birthdate;
			account.sex = accountDetails.sex;

			_context.Update(account);
			return Save();
		}

		public bool Save()
		{
			var saved = _context.SaveChanges();
			return saved > 0 ? true : false;
		}



		
	}
}
