using Microsoft.EntityFrameworkCore;
using ServiceLayer.Services.IRepositories;
using InfastructureLayer.Data;
using DomainLayer.Models;
using InfastructureLayer.Repositories;

namespace InfastructureLayer.Repositories
{
	public class MTVPaymentRepository : Repository<MTVPayment>, IMTVPaymentRepository
	{
		private readonly AppDbContext _context;

		public MTVPaymentRepository(AppDbContext context) : base(context)
		{
			_context = context;
		}
		public void Update(MTVPayment entity)
		{
			_context.Update(entity);
		}
	}
}
