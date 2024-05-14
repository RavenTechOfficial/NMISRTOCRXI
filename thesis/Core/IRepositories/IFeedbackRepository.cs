using DomainLayer.Models.ViewModels;
using DomainLayer.Models;

namespace thesis.Core.IRepositories
{
	public interface IFeedbackRepository
	{
		FeedbackViewModel GetFeedbacks();
	}
}
