using Microsoft.EntityFrameworkCore;
using ServiceLayer.Services.IRepositories;
using InfastructureLayer.Data;
using DomainLayer.Models;
using InfastructureLayer.Repositories;

namespace InfastructureLayer.Repositories
{
	public class MeatInspectionPassedForSlaughterRepository : Repository<MeatInspectionPassedForSlaughter>, IMeatInspectionPassedForSlaughterRepository
	{
		private readonly AppDbContext _context;

		public MeatInspectionPassedForSlaughterRepository(AppDbContext context) : base(context)
		{
			_context = context;
		}
		public void Update(MeatInspectionPassedForSlaughter entity)
		{
			_context.Update(entity);
		}
	}
}
