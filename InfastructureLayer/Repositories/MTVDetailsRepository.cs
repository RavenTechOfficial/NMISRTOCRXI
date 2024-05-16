using Microsoft.EntityFrameworkCore;
using ServiceLayer.Services.IRepositories;
using InfastructureLayer.Data;
using DomainLayer.Models;
using InfastructureLayer.Repositories;

namespace InfastructureLayer.Repositories
{
	public class MTVDetailsRepository : Repository<MTVDetails>, IMTVDetailsRepository
	{
		private readonly AppDbContext _context;

		public MTVDetailsRepository(AppDbContext context) : base(context)
		{
			_context = context;
		}
		public void Update(MTVDetails entity)
		{
			_context.Update(entity);
		}
	}
}
