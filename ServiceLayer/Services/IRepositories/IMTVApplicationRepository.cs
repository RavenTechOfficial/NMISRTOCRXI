using DomainLayer.Models;

namespace ServiceLayer.Services.IRepositories
{
	public interface IMTVApplicationRepository : IRepository<MTVApplication>
	{
		void Update(MTVApplication entity);
	}
}