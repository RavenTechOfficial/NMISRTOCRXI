using thesis.Core.ViewModel;
using thesis.Models;

namespace thesis.Core.IRepositories
{
	public interface IFeedbackRepository
	{
		FeedbackViewModel GetFeedbacks();
	}
}
