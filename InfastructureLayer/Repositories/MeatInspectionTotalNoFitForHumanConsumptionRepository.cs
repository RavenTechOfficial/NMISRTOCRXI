using Microsoft.EntityFrameworkCore;
using ServiceLayer.Services.IRepositories;
using InfastructureLayer.Data;
using DomainLayer.Models;
using InfastructureLayer.Repositories;

namespace InfastructureLayer.Repositories
{
	public class MeatInspectionTotalNoFitForHumanConsumptionRepository : Repository<MeatInspectionTotalNoFitForHumanConsumption>, IMeatInspectionTotalNoFitForHumanConsumptionRepository
	{
		private readonly AppDbContext _context;

		public MeatInspectionTotalNoFitForHumanConsumptionRepository(AppDbContext context) : base(context)
		{
			_context = context;
		}
		public void Update(MeatInspectionTotalNoFitForHumanConsumption entity)
		{
			_context.Update(entity);
		}
	}
}
