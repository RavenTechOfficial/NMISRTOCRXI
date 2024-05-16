using Microsoft.EntityFrameworkCore;
using ServiceLayer.Services.IRepositories;
using InfastructureLayer.Data;
using DomainLayer.Models;
using InfastructureLayer.Repositories;

namespace InfastructureLayer.Repositories
{
	public class MeatInspectionPostmortemRepository : Repository<MeatInspectionPostmortem>, IMeatInspectionPostmortemRepository
	{
		private readonly AppDbContext _context;

		public MeatInspectionPostmortemRepository(AppDbContext context) : base(context)
		{
			_context = context;
		}
		public void Update(MeatInspectionPostmortem entity)
		{
			_context.Update(entity);
		}
	}
}
