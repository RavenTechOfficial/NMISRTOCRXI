using Microsoft.EntityFrameworkCore;
using thesis.Core.IRepositories;
using thesis.Data;
using thesis.Models;

namespace thesis.Repositories
{
    public class MeatInspectionReportRepository : IMeatInspectionReportRepository
    {
        private readonly thesisContext _context;

        public MeatInspectionReportRepository(thesisContext context)
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
