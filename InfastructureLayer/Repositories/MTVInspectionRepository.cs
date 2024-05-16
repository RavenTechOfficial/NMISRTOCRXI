using Microsoft.EntityFrameworkCore;
using ServiceLayer.Services.IRepositories;
using InfastructureLayer.Data;
using DomainLayer.Models;
using InfastructureLayer.Repositories;

namespace InfastructureLayer.Repositories
{
	public class MTVInspectionRepository : Repository<MTVInspection>, IMTVInspectionRepository
	{
		private readonly AppDbContext _context;

		public MTVInspectionRepository(AppDbContext context) : base(context)
		{
			_context = context;
		}
		public void Update(MTVInspection entity)
		{
			_context.Update(entity);
		}
	}
}
