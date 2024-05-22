
using ServiceLayer.Services.IRepositories;
using DomainLayer.Models.ViewModels;
using InfastructureLayer.Data;
using DomainLayer.Models;

namespace NMISRTOCXI.Repositories
{
	public class FeedbackRepository : IFeedbackRepository
	{
        private readonly AppDbContext _context;

        public FeedbackRepository(AppDbContext context)
        {
            _context = context;
        }
        public FeedbackViewModel GetFeedbacks()
		{
            var highlydissatisfied = _context.FeedBacks.Sum(p => p.HighlyDissatisfied);
            var dissatisfied = _context.FeedBacks.Sum(p => p.Dissatisfied);
            var neutral = _context.FeedBacks.Sum(p => p.Neutral);
            var satisfied = _context.FeedBacks.Sum(p => p.Satisfied);
            var highlysatisfied = _context.FeedBacks.Sum(p => p.HighlySatisfied);

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
