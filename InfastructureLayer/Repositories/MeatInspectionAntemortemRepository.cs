using Microsoft.EntityFrameworkCore;
using ServiceLayer.Services.IRepositories;
using InfastructureLayer.Data;
using DomainLayer.Models;
using InfastructureLayer.Repositories;

namespace InfastructureLayer.Repositories
{
	public class MeatInspectionAntemortemRepository : Repository<MeatInspectionAntemortem>, IMeatInspectionAntemortemRepository
	{
		private readonly AppDbContext _context;

		public MeatInspectionAntemortemRepository(AppDbContext context) : base(context)
		{
			_context = context;
		}
		public void Update(MeatInspectionAntemortem entity)
		{
			_context.Update(entity);
		}
	}
}
