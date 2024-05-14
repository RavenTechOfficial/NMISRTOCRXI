using DomainLayer.Models;
using DomainLayer.Models.ViewModels;

namespace ServiceLayer.Services.IRepositories
{
    public interface IUsersManangementRepository
	{
		Task<IEnumerable<AccountDetails>> GetAllUsersAsync();
		Task<AccountDetails> GetAccountDetails(string accountId);
		Task<AccountDetails> GetAccountDetailsByAsyncNoTracking(string accountId);
		bool AccountDetailsExist(string id);
		bool Update(AccountUserViewModel accountDetails);
		bool Delete(AccountDetails accountDetails);	
		bool Save();

	}
}
