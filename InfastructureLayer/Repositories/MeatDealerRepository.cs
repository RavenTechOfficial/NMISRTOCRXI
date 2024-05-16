using Microsoft.EntityFrameworkCore;
using ServiceLayer.Services.IRepositories;
using InfastructureLayer.Data;
using DomainLayer.Models;
using InfastructureLayer.Repositories;

namespace InfastructureLayer.Repositories
{
	public class MeatDealerRepository : Repository<MeatDealer>, IMeatDealerRepository
	{
		private readonly AppDbContext _context;

		public MeatDealerRepository(AppDbContext context) : base(context)
		{
			_context = context;
		}
		public void Update(MeatDealer entity)
		{
			_context.Update(entity);
		}
	}
}
