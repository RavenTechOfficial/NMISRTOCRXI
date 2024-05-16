using Microsoft.EntityFrameworkCore;
using ServiceLayer.Services.IRepositories;
using InfastructureLayer.Data;
using DomainLayer.Models;
using InfastructureLayer.Repositories;

namespace InfastructureLayer.Repositories
{
	public class MTVQuizRepository : Repository<MTVQuiz>, IMTVQuizRepository
	{
		private readonly AppDbContext _context;

		public MTVQuizRepository(AppDbContext context) : base(context)
		{
			_context = context;
		}
		public void Update(MTVQuiz entity)
		{
			_context.Update(entity);
		}
	}
}
