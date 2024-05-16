using Microsoft.EntityFrameworkCore;
using ServiceLayer.Services.IRepositories;
using InfastructureLayer.Data;
using DomainLayer.Models;
using InfastructureLayer.Repositories;

namespace InfastructureLayer.Repositories
{
	public class MTVApplicationRepository : Repository<MTVApplication>, IMTVApplicationRepository
	{
		private readonly AppDbContext _context;

		public MTVApplicationRepository(AppDbContext context) : base(context)
		{
			_context = context;
		}
		public void Update(MTVApplication entity)
		{
			_context.Update(entity);
		}
	}
}
