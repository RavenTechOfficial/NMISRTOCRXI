using Microsoft.EntityFrameworkCore;
using ServiceLayer.Services.IRepositories;
using InfastructureLayer.Data;
using DomainLayer.Models;
using InfastructureLayer.Repositories;

namespace InfastructureLayer.Repositories
{
	public class MeatInspectionReceivingRepository : Repository<MeatInspectionReceiving>, IMeatInspectionReceivingRepository
	{
		private readonly AppDbContext _context;

		public MeatInspectionReceivingRepository(AppDbContext context) : base(context)
		{
			_context = context;
		}
		public void Update(MeatInspectionReceiving entity)
		{
			_context.Update(entity);
		}
	}
}
