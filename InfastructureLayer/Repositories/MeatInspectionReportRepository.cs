using Microsoft.EntityFrameworkCore;
using ServiceLayer.Services.IRepositories;
using InfastructureLayer.Data;
using DomainLayer.Models;

namespace thesis.Repositories
{
    public class MeatInspectionReportRepository : IMeatInspectionReportRepository
    {
        private readonly AppDbContext _context;

        public MeatInspectionReportRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ICollection<MeatInspectionReport>> GetAllMeatInspectionReports()
        {
            //return await _context.meatInspectionReports
            //    .Include(q => q.TotalNoFitForHumanConsumption)
            //    .Include(q => q.SummaryAndDistributionOfMIC)
            //    .Include(r => r.Receiving)
            //    .ToListAsync();
            throw new NotImplementedException();
        }
    }
}
