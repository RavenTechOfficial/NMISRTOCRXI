
using thesis.Core.IRepositories;
using DomainLayer.Models.ViewModels;
using thesis.Data;
using DomainLayer.Models;

namespace thesis.Repositories
{
	public class FeedbackRepository : IFeedbackRepository
	{
        private readonly thesisContext _context;

        public FeedbackRepository(thesisContext context)
        {
            _context = context;
        }
        public FeedbackViewModel GetFeedbacks()
		{
            var highlydissatisfied = _context.Feedbacks.Sum(p => p.HighlyDissatisfied);
            var dissatisfied = _context.Feedbacks.Sum(p => p.Dissatisfied);
            var neutral = _context.Feedbacks.Sum(p => p.Neutral);
            var satisfied = _context.Feedbacks.Sum(p => p.Satisfied);
            var highlysatisfied = _context.Feedbacks.Sum(p => p.HighlySatisfied);

            return new FeedbackViewModel
            {
                HighlyDissatisfied = highlydissatisfied,
                Dissatisfied = dissatisfied,
                Neutral = neutral,
                Satisfied = satisfied,
                HighlySatisfied = highlysatisfied
                
            };
		}
	}
}
