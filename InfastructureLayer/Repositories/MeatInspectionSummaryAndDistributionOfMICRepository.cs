using Microsoft.EntityFrameworkCore;
using ServiceLayer.Services.IRepositories;
using InfastructureLayer.Data;
using DomainLayer.Models;
using InfastructureLayer.Repositories;

namespace InfastructureLayer.Repositories
{
	public class MeatInspectionSummaryAndDistributionOfMICRepository : Repository<MeatInspectionSummaryAndDistributionOfMIC>, IMeatInspectionSummaryAndDistributionOfMICRepository
	{
		private readonly AppDbContext _context;

		public MeatInspectionSummaryAndDistributionOfMICRepository(AppDbContext context) : base(context)
		{
			_context = context;
		}
		public void Update(MeatInspectionSummaryAndDistributionOfMIC entity)
		{
			_context.Update(entity);
		}
	}
}
