using DomainLayer.Models;

namespace ServiceLayer.Services.IRepositories
{
	public interface IMTVDetailsRepository : IRepository<MTVDetails>
	{
		void Update(MTVDetails entity);
	}
}