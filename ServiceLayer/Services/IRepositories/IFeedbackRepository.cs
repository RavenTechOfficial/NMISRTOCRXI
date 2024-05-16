using DomainLayer.Models.ViewModels;
using DomainLayer.Models;

namespace ServiceLayer.Services.IRepositories
{
	public interface IFeedbackRepository : IRepository<Feedback>
	{
		void Update(Feedback feedback);	
		FeedbackViewModel GetFeedbacks();
	}
}
