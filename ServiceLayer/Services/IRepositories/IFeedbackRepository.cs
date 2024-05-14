using DomainLayer.Models.ViewModels;
using DomainLayer.Models;

namespace ServiceLayer.Services.IRepositories
{
	public interface IFeedbackRepository
	{
		FeedbackViewModel GetFeedbacks();
	}
}
