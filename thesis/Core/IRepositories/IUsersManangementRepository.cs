using thesis.Areas.Identity.Data;

namespace thesis.Core.IRepositories
{
	public interface IUsersManangementRepository
	{
		IEnumerable<AccountDetails> GetAllUsersAsync();

	}
}
