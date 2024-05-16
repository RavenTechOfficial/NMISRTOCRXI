
using ServiceLayer.Services.IRepositories;
using DomainLayer.Models.ViewModels;
using InfastructureLayer.Data;
using DomainLayer.Models;
using InfastructureLayer.Repositories;

namespace InfastructureLayer.Repositories
{
	public class FeedbackRepository : Repository<Feedback>, IFeedbackRepository
	{
        private readonly AppDbContext _context;

        public FeedbackRepository(AppDbContext context) : base(context) 
        {
            _context = context;
        }
        public void Update(Feedback entity)
        {
            _context.Update(entity);
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
