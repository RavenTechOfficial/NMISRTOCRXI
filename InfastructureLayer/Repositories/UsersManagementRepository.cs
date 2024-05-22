using Microsoft.EntityFrameworkCore;
using DomainLayer.Models;
using ServiceLayer.Services.IRepositories;
using DomainLayer.Models.ViewModels;
using InfastructureLayer.Data;

namespace NMISRTOCXI.Repositories
{
	public class UsersManagementRepository : IUsersManangementRepository
	{
		private readonly AppDbContext _context;

		public UsersManagementRepository(AppDbContext context)
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
			account.FirstName = accountDetails.firstName;
			account.LastName = accountDetails.lastName;
			account.MiddleName = accountDetails.middleName;
			account.BirthDate = accountDetails.birthdate;
			account.Gender = accountDetails.sex;

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
